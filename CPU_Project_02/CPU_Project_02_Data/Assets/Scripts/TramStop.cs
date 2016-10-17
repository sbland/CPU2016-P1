using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TramStop
{

    public string tramStopName;
    public float latitude;
    public float longitude;
    public Dictionary<string, float> tramStopData;

    public TramStop(string tramStopNameIn, float latitudeIn, float longitudeIn, Dictionary<string, float> tramStopDataIn)
    {
        tramStopName = tramStopNameIn;
        latitude = latitudeIn;
        longitude = longitudeIn;
        tramStopData = tramStopDataIn;
    }
}