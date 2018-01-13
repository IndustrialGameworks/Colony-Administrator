/*Have left original code inside, in case we need to hybridise the new and old code to achieve the desired effect.
 CAN NO LONGER BE APPLIED TO CAMERA IN CURRENT STATE, as the camera is at an angle. Which means its forward vector is also at an angle!
 Should be attached to the camera focal point until changed*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementEdge : MonoBehaviour {

    int boundary = 10; //size of the boundary zone. goes buggy at lower values, test with 1 again when running in its own window (not unity window)
    int width; //will store screen width
    int height; //will store screen height
    float scrollSpeed = 05.00f;

    void Start()
    {
        width = Screen.width; //assigns screen width to variable "width"
        height = Screen.height; //assigns screen height to variable "height"
    }

    void Update()
    {
        if (Input.mousePosition.x > width - boundary || (Input.GetKey("d"))) //checks to see if mouse input is in right boundary zone, or D keypress
        {
            //old code
            //transform.position += new Vector3(scrollSpeed * Time.deltaTime,
            //  0.0f, 0.0f); //assigns camera new vector3 on the X-axis to move camera RIGHT

            Vector3 right = transform.TransformDirection(Vector3.right*scrollSpeed*Time.deltaTime); //NEW CODE SOLVES BUG!
            transform.position += right;
        }

        if (Input.mousePosition.x < 0 + boundary || (Input.GetKey("a"))) //checks to see if the mouse input in the left boundary zone, or A keypress
        {
            //old code
            //transform.position -= new Vector3(scrollSpeed * Time.deltaTime,
            //  0.0f, 0.0f); //assigns camera new vector3 on the X-axis to move camera LEFT

            Vector3 left = transform.TransformDirection(Vector3.left * scrollSpeed * Time.deltaTime); //NEW CODE SOLVES BUG!
            transform.position += left;
        }

        if (Input.mousePosition.y > height - boundary || (Input.GetKey("w"))) //checks to see if the mouse input is in the top boundary zone, or W keypress
        {
            //old code
            //transform.position += new Vector3(0.0f, 0.0f,
            //  scrollSpeed * Time.deltaTime); //assigns new vector3 on the Y-axis to move camera UP

            Vector3 forward = transform.TransformDirection(Vector3.forward * scrollSpeed * Time.deltaTime); //NEW CODE SOLVES BUG!
            transform.position += forward;
        }

        if (Input.mousePosition.y < 0 + boundary || (Input.GetKey("s"))) //checks to see if the mouse input is in the bottom boundary zone, or S keypress
        {
            //old code
            // transform.position -= new Vector3(0.0f, 0.0f,
            //  scrollSpeed * Time.deltaTime); //assigns new vector3 on the Y-axis to move camera DOWN

            Vector3 backward = transform.TransformDirection(Vector3.back * scrollSpeed * Time.deltaTime); //NEW CODE SOLVES BUG!
            transform.position += backward;
        }

    }
}
