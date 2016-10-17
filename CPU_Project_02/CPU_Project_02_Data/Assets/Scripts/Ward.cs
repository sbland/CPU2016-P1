using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;



public class Ward
{

    public string wardName;
    public float latitude;
    public float longitude;
    public Dictionary<string, float> censusDataDictLocal;
    float cylinderSize = 2000 / GisDataStatics.scale; // This sets the size of the cylinder based on the scale of the model
    GameObject cylinder;

    //Ward Constructor
    public Ward (string wardNameIn, float latIn, float longIn, Dictionary<string, float> dataArrayIn)
    {
        wardName = wardNameIn;
        latitude = latIn;
        longitude = longIn;
        //cylinderSize = cylinderSizeIn;
        censusDataDictLocal = dataArrayIn;
    }

    

    public void Initiate ()
    {
        cylinder = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        cylinder.name = wardName;

        //offset and rescale
        latitude = latitude - GisDataStatics.offsetX;
        longitude = longitude - GisDataStatics.offsetY;

        latitude = latitude / GisDataStatics.scale;
        longitude = longitude / GisDataStatics.scale;
        


        cylinder.transform.position = new Vector3(latitude, censusDataDictLocal["travelByTram"], longitude);
        cylinder.transform.localScale = new Vector3(cylinderSize, censusDataDictLocal["travelByTram"], cylinderSize);
    }

    public void UpdateFromData(string inputName)
    {
        float width = cylinderSize-(censusDataDictLocal[inputName]/100);

        cylinder.transform.position = new Vector3(latitude, censusDataDictLocal[inputName], longitude);
        cylinder.transform.localScale = new Vector3(width, censusDataDictLocal[inputName], width);



    }

}
