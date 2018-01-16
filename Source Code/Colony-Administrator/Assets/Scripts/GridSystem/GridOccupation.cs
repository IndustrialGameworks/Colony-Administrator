using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridOccupation : MonoBehaviour
{

    [SerializeField]

    bool[] OccupationArray = new bool[GridGenerator.ArrayScale]; //creates an array to store vector3's with a size worked out by looking at the grid size divided by cell size

    private void InitializeOccupationArray() //debug code that allows us to see grid positions for now
    {
        for (int index = 0; index<OccupationArray.Length; index++)
        {
            OccupationArray[index] = false;
        }
    }

    void Start() //loads Vector3 coordinates into array
    {
        InitializeOccupationArray();
    }

    void Update()
    {
        if (Input.GetKeyDown("n")) //currenty used for debug
        {

            for (int ID = 0; ID < OccupationArray.Length; ID++)
            {
                Debug.Log(OccupationArray[ID]);
            }
        }
    }
}
