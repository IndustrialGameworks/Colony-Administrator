using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingAvailabilityMarker : MonoBehaviour {

	public Material [] indicatorMaterial; //array to hold materials
	public GameObject indicationMarker;
	Renderer rend;


	// Use this for initialization
	void Start () {

		rend = GetComponent<Renderer> (); //gets the renderer of the current component
		rend.enabled = true; // makes sure the renderer is enabled
		rend.sharedMaterial = indicatorMaterial [0]; //sets the initial material
	}
	
	// Update is called once per frame
	void Update () {
		
		transform.position = new Vector3(PointerLocation.NearestPointOnGrid.x, 1, PointerLocation.NearestPointOnGrid.z); //follows the mouser cursor
		AvailabilityDesignation(); //checks for the occupation of grid squares
		LeaveIndication();
	}

	void AvailabilityDesignation () {

		if (PointerLocation.isOccupied == false) { //gets the state of occupation from PointerLocation
			rend.sharedMaterial = indicatorMaterial [1]; //calls the second material in the array if the grid square is unnocupied
		} 

		else {
			rend.sharedMaterial = indicatorMaterial [0]; //otherwise call the first material in array
		}
	}

	void LeaveIndication ()
	{
		if (Input.GetMouseButtonDown (0) && PointerLocation.isOccupied == false) { //when left mouse button is clicked, it places an indication block if the grid square is unnoccupied
			Instantiate (indicationMarker, PointerLocation.NearestPointOnGrid, Quaternion.identity); //instantiates the indicationMarker
		}
	}
}
