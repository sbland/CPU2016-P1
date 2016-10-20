using UnityEngine;
using System.Collections;

public class TramMaker : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        //foreach (Route routePointer in XmlScheduleData.routes)
        //   {
        //       foreach(Trip tripPointer in routePointer.Trips)
        //       {
        //           tramObject = GameObject.CreatePrimitive(PrimitiveType.sphere);
        //           tramObject.name = "Tram_" + routePointer.serviceID + tripPointer.tripId;
        //       }
        //   }

        foreach (Trip tripPointer in XmlScheduleData.routes["Serv000001"].trips)
        {
            GameObject tramObject = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            tramObject.name = "Tram_" + "Serv000001" + "_" + tripPointer.tripId;
            
        }

    }
}
