using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour {

    float cameraDistanceMax = 10f;
    float cameraDistanceMin = 2.5f;
    public float cameraDistance;
    float scrollSpeed = 400f;
    //float cameraAngle = 35f; //needs to change with the camera X rotation
    //bool isZooming; //unused check of whether camera is zooming


    void Update() {

        cameraDistance = Input.GetAxis("Mouse ScrollWheel") * scrollSpeed * Time.deltaTime; //distance camera will move with each 'increment' of scrolling
        if (transform.position.y < cameraDistanceMin && cameraDistance > 0){ //negates scrolling if attempting to go below lower limit
           //isZooming = false;
        } else
        {
            if (transform.position.y > cameraDistanceMax && cameraDistance < 0) //negates scrolling if attempting to go above upper limit
            {
                //isZooming = false;
            }
            else
            {
                /*isZooming = true;
                transform.position += new Vector3(0.0f,
                cameraDistance * Mathf.Sin(cameraAngle),  //move camera along its own z axis (instead of worlds z axis) by multiplying y and z by sin/cos of angle of cameras rotation
                -cameraDistance * Mathf.Cos(cameraAngle)); //z is negative as scrolling needs to be inverted (scroll down to get closer and move down)*/

                Vector3 forward = transform.TransformDirection(Vector3.forward * cameraDistance); //NEW CODE SOLVES BUG!
                transform.position += forward;
            }

        }
    }
}