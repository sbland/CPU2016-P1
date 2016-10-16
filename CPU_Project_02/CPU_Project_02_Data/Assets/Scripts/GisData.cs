using UnityEngine;
using System.Collections;
using System.IO;
using System.Xml;
using System;
using System.Collections.Generic;
using System.Text;

public class GisDataStatics
{
    public static float scale;// = 400;
    public static float offsetX;// = 397000;
    public static float offsetY;// = 395000;
}

public class GisData : MonoBehaviour
{
    
    public string filePath;
    public float scale = 400;
    public float offsetX = 397000;
    public float offsetY = 395000;

    public GameObject[] objectList;

    public int valueOut;

    public TextAsset gisDataFile;
    public TextMesh textTitle;
    


    // Use this for initialization
    void Start()
    {

        ReadGISData();


    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ReadGISData()
    {



        Debug.Log("TEST");

        XmlDocument gisXml = new XmlDocument();

        //try { gisXml.Load(gisData.text); }
        //catch { Debug.Log("Failed to load file"); }

        gisXml.LoadXml(gisDataFile.text);

        XmlNodeList oaPointList = gisXml.DocumentElement.ChildNodes;

        StartCoroutine(coroutine(oaPointList));

        
    }
    private IEnumerator coroutine(XmlNodeList nodeList)
    {
        foreach (XmlNode xmlNodeI in nodeList)
        {
            //## wait 1 frame before adding a cylinder
            //yield return new WaitForEndOfFrame();

            //Assign variables from xml too c# vars
            float gisZ = float.Parse(xmlNodeI["X"].InnerText);
            float gisX = float.Parse(xmlNodeI["Y"].InnerText);
            float inverseScale = 500 / scale; // This sets the size of the cylinder based on the scale of the model
            //offset and rescale
            gisX = gisX - offsetX;
            gisZ = gisZ - offsetY;

            gisX = gisX / scale;
            gisZ = gisZ / scale;


            //Assign data from xml to variables
            float censusDataStudents = float.Parse(xmlNodeI["StudentFT"].InnerText);
            float censusDataTravelByTram = float.Parse(xmlNodeI["travelByTram"].InnerText);
            float censusDataTravelByCar = float.Parse(xmlNodeI["travelByCar"].InnerText);


            //Create an array to store each data set
            float[] censusData; //Better to make this a dictionary?
            censusData = new float[10] ;

            //Add data to array to pass to the Ward class
            censusData[0] = censusDataStudents;
            censusData[1] = censusDataTravelByTram;
            censusData[1] = censusDataTravelByCar;

           

            

            textTitle.text = "travelByCar";

            
            //create a new ward
            Ward newWard = new Ward(xmlNodeI["name"].InnerText,gisX,gisZ, inverseScale,censusData);
            newWard.Initiate();


            //// Below moved to Ward class////
            //GameObject cylinder = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            //cylinder.name = xmlNodeI["name"].InnerText;
            //cylinder.transform.position = new Vector3(-gisX, gistravelByCar, gisZ);
            //cylinder.transform.localScale = new Vector3(inverseScale, gistravelByCar, inverseScale);

           // cylinder.gameObject.AddComponent<Ward>();

                       
        }
        yield break;

    }

}
