using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TramStop
{

    public string tramStopName;
    public string tramStopId;
    public float coordX;
    public float coordY;
    public Dictionary<string, float> tramStopData;
    GameObject cylinder;
    float cylinderSize = 300 / GisDataStatics.scale; // This sets the size of the cylinder based on the scale of the model

    public TramStop(string tramStopNameIn,string tramStopIdIn, float coordXIn, float coordYIn)
    {
        tramStopName = tramStopNameIn;
        tramStopId = tramStopIdIn;
        coordX = coordXIn;
        coordY = coordYIn;
       
        
    }

    public void Initiate()
    {
        cylinder = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        cylinder.name = tramStopName;

        //offset and rescale
        coordX = coordX - GisDataStatics.offsetX;
        coordY = coordY - GisDataStatics.offsetY;


        coordX = coordX / GisDataStatics.scale;
        coordY = coordY / GisDataStatics.scale;
        


        cylinder.transform.position = new Vector3(coordX, 5, coordY);
        cylinder.transform.localScale = new Vector3(cylinderSize, 5, cylinderSize);
    }

    public void UpdateFromData()
    {
        cylinder.transform.position = new Vector3(coordX, 10, coordY);
        cylinder.transform.localScale = new Vector3(cylinderSize, 10, cylinderSize);
    }
}