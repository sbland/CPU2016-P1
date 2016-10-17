using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BusStop {

    public string busStopName;
    public float latitude;
    public float longitude;
    public Dictionary<string, float> busStopData;

    public BusStop(string busStopNameIn, float latitudeIn, float longitudeIn, Dictionary<string, float> busStopDataIn)
        {
            busStopName = busStopNameIn;
            latitude = latitudeIn;
            longitude = longitudeIn;
            busStopData = busStopDataIn;
        }
}
