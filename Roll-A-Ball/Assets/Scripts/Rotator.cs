using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        //Rotates the object.
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
    }
}
