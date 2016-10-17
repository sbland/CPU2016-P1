using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class Ward
{

    public string wardName;
    public float latitude;
    public float longitude;
    public float cylinderSize;
    public Dictionary<string, float> censusDataDictLocal;


    //Ward Constructor
    public Ward (string wardNameIn, float latIn, float longIn, Dictionary<string, float> dataArrayIn, float cylinderSizeIn)
    {
        wardName = wardNameIn;
        latitude = latIn;
        longitude = longIn;
        cylinderSize = cylinderSizeIn;
        censusDataDictLocal = dataArrayIn;
    }

    

    public void Initiate ()
    {
        GameObject cylinder = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        cylinder.name = wardName;

        //offset and rescale
        latitude = latitude - GisDataStatics.offsetX;
        longitude = longitude - GisDataStatics.offsetY;

        latitude = latitude / GisDataStatics.scale;
        longitude = longitude / GisDataStatics.scale;



        cylinder.transform.position = new Vector3(latitude, censusDataDictLocal["travelByTram"], longitude);
        cylinder.transform.localScale = new Vector3(cylinderSize, censusDataDictLocal["travelByTram"], cylinderSize);
    }

   
}
