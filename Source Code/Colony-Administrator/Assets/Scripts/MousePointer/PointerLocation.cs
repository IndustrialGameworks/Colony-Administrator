using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerLocation : MonoBehaviour {
	public static Vector3 positionOfMouse;
	public static Vector3 NearestPointOnGrid;
	GridGenerator NewGrid = new GridGenerator(); //create an instance of the grid here so grid methods can be accessed

	Vector3 occupationArrayVector; //stores the value as it appears in the array
	bool gridMatch; //if the nearest point on grid matches the array value, changes to true
	bool isOccupied;
	Vector3 checkGrid; //stores nearest point on grid to allow looking for changes in mouse position
	int currentGridIndex; //current index number of the grid the mouse is located at

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

		PointerInput (); //call mouse input
		OccupationCheck (); //check occupation
		GridMatch (); //debugging data, can be removed when complete

	}

	void OnGUI()
	{
		GUILayout.BeginArea(new Rect(20, 20, 250, 120)); //create basis for gui output
		GUILayout.Label ("Vector: " + NearestPointOnGrid); //show nearest point on grid on gui
		GUILayout.Label ("Grid Matched: " + gridMatch);
		GUILayout.Label ("occupationArrayVector: " + occupationArrayVector);
		GUILayout.Label ("Current Grid index: " + currentGridIndex);
		GUILayout.Label ("Is occupied: " + isOccupied);
		GUILayout.EndArea(); //close top left section of gui
	}

	void PointerInput()
	{
		if (Input.GetMouseButtonDown(0)) //This allows to simulate grid occupation
		{
			Debug.Log ("Left Click");
			GridOccupation.OccupationArray[currentGridIndex] = true; //sets the value in the array to true to simulate occupation
		}
		if (Input.GetMouseButtonDown(1)) //This allows to simulate grid occupation
		{
			Debug.Log ("Right Click");
		}
	}

	void OccupationCheck()
	{
		foreach (Vector3 gridLocation in GridGenerator.GridIndentifier) //checks each value in the grid indentifier array
		{
			if (gridLocation.Equals (NearestPointOnGrid)){ //if the gridLocation in Grid Indentifier matches nearest point on grid
				occupationArrayVector = gridLocation; //sets the occupation array vector to the first matching indexed value
				currentGridIndex = System.Array.IndexOf (GridGenerator.GridIndentifier, NearestPointOnGrid); //gets the current index of the first value matching nearest point on grid
			}
		}
		isOccupied = GridOccupation.OccupationArray [currentGridIndex]; //sets is occupied to the current occupation status of the grid
	}

	void GridMatch() //debugging data, can be removed when complete
	{
		if (occupationArrayVector == NearestPointOnGrid) { //used to check if the value in the array is being matched to nearest point on grid coordinates
			gridMatch = true;
		}
		if (occupationArrayVector != NearestPointOnGrid) { //used to check if the value in the array is being matched to nearest point on grid coords
			gridMatch = false;
		}
	}
}
