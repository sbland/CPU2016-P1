using UnityEngine;
using System.Collections;



public class TramClass {

    GameObject tramObject;

    public void initiate()
    {
        tramObject = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        tramObject.transform.position = new Vector3(0, TramData.tramListAvailable.Count, 0);
        tramObject.name = "Tram_" + TramData.tramListAvailable.Count;
    }

}
