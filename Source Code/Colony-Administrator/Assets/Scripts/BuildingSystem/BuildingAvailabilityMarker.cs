using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingAvailabilityMarker : MonoBehaviour {

	Vector3 track;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		/*track = transform.TransformDirection ((PointerLocation.positionOfMouse.x), 0, (PointerLocation.positionOfMouse.z)); //NEW CODE SOLVES BUG!
		transform.position = track;*/

		transform.position = new Vector3(PointerLocation.NearestPointOnGrid.x, 1, PointerLocation.NearestPointOnGrid.z);
	}
}
