using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerLocation : MonoBehaviour {
	Vector3 positionOfMouse;
	Vector3 NearestPointOnGrid;
	GridGenerator NewGrid = new GridGenerator(); //create an instance of the grid here so grid methods can be accessed

	void Update () {
		Vector3 cameraLocation = Camera.main.transform.position; //retrieve cameras location and saves it to a variable
		RaycastHit hit; //raycasthit stores information regarding where a raycast ends
		if (Physics.Raycast (Camera.main.ScreenPointToRay (Input.mousePosition), out hit, 100)) { //if the raycast hits the terrain
			positionOfMouse = hit.point; //the endpoint of the raycast corresponds to mouse position relative to terrain
			Debug.Log (positionOfMouse); //needs to be finalised for debug mode
			NearestPointOnGrid = NewGrid.GetNearestPointOnGrid (positionOfMouse); //retrieves getnearestpointongrid method from the new grid
		} else {
			Debug.Log ("Raycast cannot find terrain");//debug error message returned if raycast cant find terrain
		}
	}

	void OnGUI()
	{
		GUILayout.BeginArea(new Rect(20, 20, 250, 120)); //create basis for gui output
		GUILayout.Label ("Vector: " + NearestPointOnGrid); //show nearest point on grid on gui
		GUILayout.EndArea(); //close top left section of gui
	}
}
