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
    public float scale = 50;
    public float offsetX = 397000;
    public float offsetY = 395000;

    public TextAsset gisDataFile;
    public TextMesh textTitle;



    // Use this for initialization
    void Start()
    {
        GisDataStatics.scale = scale;
        GisDataStatics.offsetX = offsetX;
        GisDataStatics.offsetY = offsetY;
        
        LoadGisData(gisDataFile);

    }

    // Update is called once per frame
    //void Update()
    //{

    //}

   


    public void LoadGisData(TextAsset xmlFileIn)
    {
        XmlDocument gisXml = new XmlDocument();

        try { gisXml.LoadXml(xmlFileIn.text); }
        catch { Debug.Log("Failed to load xml file"); }

        StartCoroutine(LoadingCoroutine(gisXml)); //allows loading of assets while continuing other tasks


    }

    private IEnumerator LoadingCoroutine(XmlDocument inputXml)
    {
        XmlNodeList nodeList = inputXml.DocumentElement.ChildNodes; // opens the first level of objects in the xml file (E.g the wards)

        foreach (XmlNode xmlNodeI in nodeList)
        {
            //## Load 1 item per frame
            yield return new WaitForEndOfFrame();

            //Load data
            float posLat = float.Parse(xmlNodeI["X"].InnerText);
            float posLong = float.Parse(xmlNodeI["Y"].InnerText);
            float inverseScale = 500 / scale; // This sets the size of the cylinder based on the scale of the model
            string wardName = xmlNodeI.Attributes["name"].Value;

            Dictionary<string, float> censusDataDict = new Dictionary<string, float>();



            foreach (XmlNode xmlChild in xmlNodeI)
            {
                


               
                Debug.Log(xmlChild.Name);
                float parseFloat;

                
                parseFloat = float.Parse(xmlChild.InnerText);
                      
                censusDataDict.Add(xmlChild.Name, parseFloat);

            }





            //create a new ward
            Ward newWard = new Ward(wardName, posLat, posLong, censusDataDict, inverseScale);
            newWard.Initiate();

        }


        yield break;
    }
}
