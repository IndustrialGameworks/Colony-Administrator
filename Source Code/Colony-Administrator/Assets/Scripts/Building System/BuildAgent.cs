using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildAgent : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		CameraRotation ();
	}

	void CameraRotation() {
		var RotatePoint = GameObject.Find("Player"); //Gets the capsule acting as the rotation coordinates, assigns it to a variable
		float rotationSpeed = 30f;

		if (Input.GetKey("q")) //When Q button is held, camera rotates around rotation point
		{
			transform.RotateAround(RotatePoint.transform.position, Vector3.up, rotationSpeed * Time.deltaTime); //(object to rotate around, direction of orbit, angle * time). Vector3.up rotates camera left for unknown reasons
			print("Q key pressed"); //debug line to test if Q was actually taking input
		}
		else if (Input.GetKey("e")) //When E button is held, camera rotates around rotation point
		{
			transform.RotateAround(RotatePoint.transform.position, Vector3.down, rotationSpeed * Time.deltaTime); //Vector3.down rotates camera right for unknown reasons
			print("E key pressed"); //debug line to test if E was actually taking input
		}
	}
}
