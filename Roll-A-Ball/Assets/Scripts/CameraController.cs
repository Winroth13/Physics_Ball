using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //The player object.
    public GameObject player;
    
    //The camera's offset compared to the player ojbect.
    private Vector3 offset;

    //Variable for the rotationspeed of the cmarea.
    public float rotationSpeed = 500.0f;

    //The rotation of the camera relavite to it's starting position.
    private Quaternion rotaion = Quaternion.identity;

    //The fransform of the main camera.
    public Transform mainCamera;

    //The current zoom level.
    public float zoomLevel;

    //The sensitivity of the zoom.
    public float zoomSensitivity = 1;

    //The speed of the zoom effect.
    public float zoomSpeed = 20;

    //The current zoom position of the camera.
    float zoomPosition;

    //The in game menu.
    public GameObject gameMenuObject;

    // Start is called before the first frame update
    void Start()
    {
        //Sets the starting position for the camera.
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //Moves the camera along with the player object.
        transform.position = player.transform.position + offset;

        //Only lets the camera rotate while not in the in game menu.
        if (gameMenuObject.activeSelf == false)
        {
            //Sets the rotation angle for the camera.
            rotaion.y -= Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;
            rotaion.x += Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;

            //Stops the camera for going below the ground or over the player object.
            //It stays between 10 and 80 degrees in pitch.
            rotaion.y = Mathf.Clamp(rotaion.y, -35, 35);

            //Applies the new rotation to the camera.
            transform.rotation = Quaternion.Euler(rotaion.y, rotaion.x, rotaion.z);
        }

        //The change in zoom level.
        zoomLevel += Input.mouseScrollDelta.y * zoomSensitivity;

        //Regulates the zoomlevel to be between the camera's starting position and right infront of the ball.
        zoomLevel = Mathf.Clamp(zoomLevel, 0, 13);

        //Sets the movement for the camera.
        zoomPosition = Mathf.MoveTowards(zoomPosition, zoomLevel, zoomSpeed * Time.deltaTime);

        //Moves the camera to it's new zoom position.
        transform.position = transform.position + (mainCamera.forward * zoomPosition);
    }
}
