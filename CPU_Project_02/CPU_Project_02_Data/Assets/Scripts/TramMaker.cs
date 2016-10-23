///
///Loads all trams into list at start
///





using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TramData
{
    public static List<TramClass> tramListAvailable = new List<TramClass>();

}

public class TramMaker : MonoBehaviour {

    public int tramCount = 10;
    int tempCounter = 1;

    // Use this for initialization
    void Start () {
        while (tempCounter <= tramCount)
        {
            TramClass tram = new TramClass();
            TramData.tramListAvailable.Add(tram);
            tram.initiate();
            tempCounter++;
        }
    }
	
	// Update is called once per frame
	void Update () {

        

    }
}
