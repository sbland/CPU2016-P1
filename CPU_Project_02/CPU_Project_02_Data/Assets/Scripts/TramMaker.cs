///
///Loads all trams into list at start
///





using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TramData
{
    public static List<GameObject> tramListAvailable = new List<GameObject>();

}

public class TramMaker : MonoBehaviour {

    public int tramCount = 10;
    int tempCounter = 1;

    // Use this for initialization
    void Start () {
        while (tempCounter <= tramCount)
        {
            GameObject tram = new GameObject();
            GameObject tramGeometry = GameObject.CreatePrimitive(PrimitiveType.Capsule);

            tramGeometry.transform.localScale += new Vector3(7,7,7);
            Renderer objRender = tramGeometry.GetComponent<Renderer>();
            objRender.material.color = new Color(150, 50, 50);



            tram.name = "Tram_" + tempCounter;
            tramGeometry.name = "Tram_" + tempCounter + "_Geometry";
            tramGeometry.transform.parent = tram.transform;

            TramData.tramListAvailable.Add(tram);
            TramClass tramComponent = tram.AddComponent<TramClass>();
            tramComponent.initiate();
            tempCounter++;

        }
    }
	
	//// Update is called once per frame
	//void Update () {

        

 //   }
}
