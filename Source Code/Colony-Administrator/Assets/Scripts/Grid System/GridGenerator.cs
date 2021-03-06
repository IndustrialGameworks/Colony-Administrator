﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGenerator : MonoBehaviour {

    [SerializeField]

    public static float size = 1.0f; //size of grid cells (in metres)
    public static int GridHeight = 17; //x axis length (metres)     [DONT MAKE THIS REALLY BIG AND DRAW A MILLION SPHERES]
    public static int GridWidth = 17; //z axis length (metres)      [YOU WILL BREAK EVERYTHING INCLUDING THIS POOR PC :( ]
	public static float offset = 0.5f;

    static float ArrayMath = ((GridHeight / size) * (GridWidth / size)); //does the math to get overall number of grid squares
    public static int ArrayScale = Mathf.RoundToInt(ArrayMath); //needs to print array to screen for debug
	public Vector3 NearestPointOnGrid;
	public static Vector3[] GridIndentifier = new Vector3[ArrayScale]; //creates an array to store vector3's with a size worked out by looking at the grid size divided by cell size

    public Vector3 GetNearestPointOnGrid (Vector3 position) //general purpose snap-to-grid code
    {
        int xCount = Mathf.RoundToInt(position.x / size);
        int yCount = Mathf.RoundToInt(position.y / size);
        int zCount = Mathf.RoundToInt(position.z / size); //division and multiplication of size allows different sizes of grid to be rounded to

        Vector3 result = new Vector3( //(the) result is the rounded version of the input vector
			(float)xCount * size,
            (float)yCount * size,
            (float)zCount * size);
        return result;
    }
    private void OnDrawGizmos() //debug code that allows us to see grid positions for now
    {
        Gizmos.color = Color.yellow;
        for(float x = 0; x < GridHeight; x += size)
        {
            for(float z = 0; z < GridWidth; z += size)
            {
                var point = GetNearestPointOnGrid(new Vector3(x, 0f, z));
				point += new Vector3 (-offset, 0, -offset);
                Gizmos.DrawSphere(point, 0.1f);
            }
        }
    }

    void Start() //loads Vector3 coordinates into array
    {
        int GridID = 0;  //starts at the lowest subgrid ID

        for (float x = 0; x < GridHeight; x += size) //runs through getting nearest point on grid again, coordinates stored in SubGridIndentifier
        {
            for (float z = 0; z < GridWidth; z += size)
            {
                var point = GetNearestPointOnGrid(new Vector3(x, 0f, z)); //assigns nearest point on grid to "point" on each iteration
                GridIndentifier[GridID] = point; //loads the current vector of "point" into the array
                GridID++; //runs through all the subgrid ID's on each iteration of loop
            }
        }

    }

    void Update()
    {
        if (Input.GetKeyDown("b")) //currenty used for debug
        {

            for (int ID = 0; ID < ArrayScale; ID++)
            {
                Debug.Log(GridIndentifier[ID]);
            }
        }
    }
}
