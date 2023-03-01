using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    //The playr object's speed.
    public float speed = 0;

    //The text to count pickups.
    public TextMeshProUGUI countText;

    //The win text.
    public GameObject winTextObject;

    //The in game menu.
    public GameObject gameMenuObject;

    //The extra jump text.
    public GameObject extraJumpObject;

    //The extra jump parent.
    public GameObject extraJumpParent;

    //The object's body.
    private Rigidbody rb;

    //The counter for amount of pickups collected.
    private int count;

    //Movement in the X-axis.
    private float movementX;

    //Movement in the Y-axis.
    private float movementY;

    //The strength of the player object's jump.
    public float jumpStrength = 300.0f;

    //The number of pickups needed to pick up to win.
    public int pickUpsToWin = 7;

    // Start is called before the first frame update
    void Start()
    {
        //Gets the body component.
        rb = GetComponent<Rigidbody>();

        //Sets count to 0.
        count = 0;

        //Updates counting text.
        SetCountText();

        //Hides win text.
        winTextObject.SetActive(false);

        //Hides game menu.
        gameMenuObject.SetActive(false);

        //Hides extra jump text.
        extraJumpObject.SetActive(false);

        //Hides cursor.
        Cursor.visible = false;
    }

    //Calculations for movement.
    void OnMove(InputValue movementValue)
    {
        //Creates a movement vector from the movement inputs.
        Vector2 movementVector = movementValue.Get<Vector2>();

        //Sets movement in the X- and Y-axis to that of the X- and Y-axis in the movement vector.
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    //Updating pickup text.
    void SetCountText()
    {
        //Diplays amount of collected pickups.
        countText.text = count.ToString() + "/" + pickUpsToWin + "Collected";

        //Displays win message and menu if you have collected all pickups.
        if (count >= pickUpsToWin)
        {
            winTextObject.SetActive(true);
            gameMenuObject.SetActive(true);

            //Hides cursor.
            Cursor.visible = true;
        }
    }

    //Called every frame.
    void Update()
    {
        //When space is pressed.
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Creates a RaycastHit.
            RaycastHit hit;

            //Tests to see if the player object is on the ground.
            if (Physics.Raycast(transform.position, -Vector3.up, out hit, 1))
            {
                //Makes the player object jump.
                rb.AddForce(0.0f, jumpStrength, 0.0f);
            }
            else if (extraJumpObject.activeSelf == true)
            {
                //Makes the player object jump.
                rb.AddForce(0.0f, jumpStrength, 0.0f);

                //Hides the extra jump text.
                extraJumpObject.SetActive(false);

                //Activates the extra jump parent.
                extraJumpParent.SetActive(true);
            }
        }

        //When escape is pressed.
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //If the game menu is shown, it is hidden, otherwise it is shown.
            if (gameMenuObject.activeSelf == true)
            {
                gameMenuObject.SetActive(false);

                //Shows cursor.
                Cursor.visible = false;
            }
            else
            {
                gameMenuObject.SetActive(true);

                //Hides cursor.
                Cursor.visible = true;
            }
        }
    }

    //Updates physics.
    void FixedUpdate()
    {
        //Collects the forward and right direction from the camera.
        var forward = Camera.main.transform.forward;
        var right = Camera.main.transform.right;

        //Projects the directions on a 2d plane along the ground, and makes them 1 unit long.
        forward.y = 0f;
        right.y = 0f;
        forward.Normalize();
        right.Normalize();

        //Multiplies the movement by the direction of the movements and creates a vector3 with the movement direction of the object.
        Vector3 movementDirection = forward * movementY + right * movementX;

        //Adds the vector3 as force on the player object.
        rb.AddForce(movementDirection * speed);
    }

    //Trigger on collision with objects.
    void OnTriggerEnter(Collider other)
    {
        //On collision with pickup object.
        if (other.gameObject.CompareTag("PickUp"))
        {
            //Inactive pickup object.
            other.gameObject.SetActive(false);

            //Increase ,counter for pickups collected by 1.
            count += 1;

            //Pudates pickup text.
            SetCountText();
        }

        //On collision with extra jump object.
        if (other.gameObject.CompareTag("Extra Jump"))
        {
            //Deactivates extra jump parent.
            extraJumpParent.SetActive(false);

            //Shows the extra jump text.
            extraJumpObject.SetActive(true);
        }
    }
}
