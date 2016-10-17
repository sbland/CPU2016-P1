using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TramStop
{

    public string tramStopName;
    public float latitude;
    public float longitude;
    public Dictionary<string, float> tramStopData;
    GameObject cylinder;
    float cylinderSize = 300 / GisDataStatics.scale; // This sets the size of the cylinder based on the scale of the model

    public TramStop(string tramStopNameIn, float latitudeIn, float longitudeIn, Dictionary<string, float> tramStopDataIn)
    {
        tramStopName = tramStopNameIn;
        latitude = latitudeIn;
        longitude = longitudeIn;
        tramStopData = tramStopDataIn;
        
    }

    public void Initiate()
    {
        cylinder = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        cylinder.name = tramStopName;

        //offset and rescale
        latitude = latitude - GisDataStatics.offsetX;
        longitude = longitude - GisDataStatics.offsetY;
        

        latitude = latitude / GisDataStatics.scale;
        longitude = longitude / GisDataStatics.scale;
        


        cylinder.transform.position = new Vector3(latitude, 5, longitude);
        cylinder.transform.localScale = new Vector3(cylinderSize, 5, cylinderSize);
    }

    public void UpdateFromData()
    {
        cylinder.transform.position = new Vector3(latitude, 10, longitude);
        cylinder.transform.localScale = new Vector3(cylinderSize, 10, cylinderSize);
    }
}