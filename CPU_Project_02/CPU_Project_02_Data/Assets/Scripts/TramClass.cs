using UnityEngine;
using System.Collections;



public class TramClass {

    GameObject tramObject;
    public Trip currentTrip;
    public Route currentRoute;


    public void initiate()
    {
        tramObject = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        tramObject.transform.position = new Vector3(0, TramData.tramListAvailable.Count, 0);
        tramObject.name = "Tram_" + TramData.tramListAvailable.Count;
    }

    public void startTrip()
    {
        //tramObject.transform.position = new Vector3(XmlScheduleData.tramStops["9400ZZMAAMO1"].coordX,0, XmlScheduleData.tramStops["9400ZZMAAMO1"].coordY);
        //tramObject.transform.position = new Vector3(currentRoute.stopsOnRoute["Stop1"].coordX, 0, currentRoute.stopsOnRoute["Stop1"].coordY);

    }
    
}
