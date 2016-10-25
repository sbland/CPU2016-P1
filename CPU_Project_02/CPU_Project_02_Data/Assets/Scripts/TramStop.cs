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
    public GameObject tramStopGeometry;
    float cylinderSize = 300 / GisDataStatics.scale; // This sets the size of the cylinder based on the scale of the model
    Vector3 position;

    public TramStop(string tramStopNameIn,string tramStopIdIn, float coordXIn, float coordYIn)
    {
        tramStopName = tramStopNameIn;
        tramStopId = tramStopIdIn;
        coordX = coordXIn;
        coordY = coordYIn;
       
        
    }

    public void Initiate()
    {
        //Add seld to master dictionary of all tram stops
        try { XmlScheduleData.tramStops.Add(tramStopId, this); }
        catch { Debug.Log("Failed to add " + tramStopName + " to dictionary"); }


        //create cyclinder to represent tram stop
        tramStopGeometry = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        tramStopGeometry.name = tramStopName;

        //offset and rescale
        coordX = coordX - GisDataStatics.offsetX;
        coordY = coordY - GisDataStatics.offsetY;


        coordX = coordX / GisDataStatics.scale;
        coordY = coordY / GisDataStatics.scale;



        tramStopGeometry.transform.position = new Vector3(coordX, 5, coordY);
        tramStopGeometry.transform.localScale = new Vector3(cylinderSize, 5, cylinderSize);

        //position = new Vector3()
    }

    //public void UpdateFromData()
    //{
    //    cylinder.transform.position = new Vector3(coordX, 10, coordY);
    //    cylinder.transform.localScale = new Vector3(cylinderSize, 10, cylinderSize);
    //}
}