using UnityEngine;
using System.Collections;

public class GisDataStatics
{
    public static float scale;
    public static float offsetX;
    public static float offsetY;
}

public class Settings : MonoBehaviour {

    public float scale = 500;
    public float offsetX = 397000;
    public float offsetY = 395000;

    // Use this for initialization
    void Awake () {

        //Assigns the values set in the unity editor to the standard c# class above. These variables can then be accessed from other classes.
        GisDataStatics.scale = scale;
        GisDataStatics.offsetX = offsetX;
        GisDataStatics.offsetY = offsetY;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
