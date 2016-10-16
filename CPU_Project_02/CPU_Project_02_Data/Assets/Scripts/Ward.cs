using UnityEngine;
using System.Collections;



public class Ward
    {

    public string wardName;
    public float latitude;
    public float longitude;
    public float cylinderSize;
    public float[] dataArray;


    //Ward Constructor
    public Ward (string wardNameIn, float latIn, float longIn,float cylinderSizeIn, float[] dataArrayIn)
    {
        wardName = wardNameIn;
        latitude = latIn;
        longitude = longIn;
        cylinderSize = cylinderSizeIn;
        dataArray = dataArrayIn;
    }

    

    public void Initiate ()
    {
        GameObject cylinder = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        cylinder.name = wardName;
        cylinder.transform.position = new Vector3(-latitude, dataArray[1], longitude);
        cylinder.transform.localScale = new Vector3(cylinderSize, dataArray[1], cylinderSize);
    }

   
}
