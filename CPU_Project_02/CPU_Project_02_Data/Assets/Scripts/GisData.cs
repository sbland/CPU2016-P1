﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.IO;
using System.Xml;
using System;
using System.Collections.Generic;
using System.Text;



public class GisDataObjects
{
    public static List<TramStop> tramStops = new List<TramStop>();
    public static List<Ward> wards = new List<Ward>();
}

public class GisData : MonoBehaviour
{
    


    public TextAsset[] gisDataFiles;
    public TextMesh textTitle;
    public Text loadingText;

    
    


    // Use this for initialization
    void Start()
    {
        LoadGisData(gisDataFiles); //On start load in the data from the xml files

    }

    //Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
          
            foreach (Ward ward in GisDataObjects.wards)
            {
                ward.UpdateFromData("travelByBus");
            }
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            

            foreach (Ward ward in GisDataObjects.wards)
            {
                ward.UpdateFromData("travelByCar");
            }
        }
    }




    public void LoadGisData(TextAsset[] xmlFilesIn)
    {
        foreach(TextAsset xmlFileIn  in xmlFilesIn)
        {
            XmlDocument gisXml = new XmlDocument(); //new xml var to store xml doc 

            try { gisXml.LoadXml(xmlFileIn.text); }
            catch { Debug.Log("Failed to load xml file"); } //load the xml doc into the xml var

            Debug.Log(gisXml.DocumentElement.GetAttribute("name"));

           StartCoroutine(LoadingCoroutine(gisXml, gisXml.DocumentElement.GetAttribute("name"))); //Start loading data from xml doc to a c# object. Also allows loading of assets while continuing other tasks

        }


        
        
    }

    private IEnumerator LoadingCoroutine(XmlDocument inputXml, string dataTitle)
    {
        XmlNodeList nodeList = inputXml.DocumentElement.ChildNodes; // opens the first level of objects in the xml file (E.g the wards)

        foreach (XmlNode xmlNodeI in nodeList)
        {
            loadingText.text = "Loading...";
            //## Load 1 item per frame
            yield return new WaitForEndOfFrame();

            //Load data
            float posLat = float.Parse(xmlNodeI["X"].InnerText);
            float posLong = float.Parse(xmlNodeI["Y"].InnerText);
            string rowName = xmlNodeI.Attributes["name"].Value;
            Dictionary<string, float> censusDataDict = new Dictionary<string, float>(); //create dictionary storing all data in each xml object


            //Iterate over each row in the xml (Each row is a seperate ward or bus stop etc) and add the data to the dictionary
            foreach (XmlNode xmlChild in xmlNodeI)
            {
                float parseFloat = float.Parse(xmlChild.InnerText);
                censusDataDict.Add(xmlChild.Name, parseFloat); //I.e. ("travelByTram", "30.3")
            }
            
            
            switch(dataTitle)
            {
                case "Wards":
                    //create a new object from the ward class to store each ward.
                    Ward newWard = new Ward(rowName, posLat, posLong, censusDataDict);
                    GisDataObjects.wards.Add(newWard);
                    newWard.Initiate();
                    break;                
                default:
                    break;
            }


            

        }//end foreach

        loadingText.text = "Loading...Complete";
        yield return new WaitForSeconds(2);
        loadingText.text = "";
        yield break;
    }//end LoadingCoroutine


    public void UpdateWardTravelByCar()
    {
        foreach (Ward ward in GisDataObjects.wards)
        {
            ward.UpdateFromData("travelByCar");
        }
    }

    public void UpdateWardTravelByBus()
    {
        foreach (Ward ward in GisDataObjects.wards)
        {
            ward.UpdateFromData("travelByBus");
        }
    }
    public void UpdateWardTravelByTram()

    {
        foreach (Ward ward in GisDataObjects.wards)
        {
            ward.UpdateFromData("travelByTram");
        }
    }

    public void UpdateWardTravelByBike()

    {
        foreach (Ward ward in GisDataObjects.wards)
        {
            ward.UpdateFromData("travelByBike");
        }
    }

    public void UpdateWardTravelByFoot()

    {
        foreach (Ward ward in GisDataObjects.wards)
        {
            ward.UpdateFromData("travelByFoot");
        }
    }

    public void UpdateWardStudentFT()

    {
        foreach (Ward ward in GisDataObjects.wards)
        {
            ward.UpdateFromData("StudentFT");
        }
    }

    public void UpdateWardEmployedFT()

    {
        foreach (Ward ward in GisDataObjects.wards)
        {
            ward.UpdateFromData("EmployedFT");
        }
    }

    public void UpdateWardEmployedPT()

    {
        foreach (Ward ward in GisDataObjects.wards)
        {
            ward.UpdateFromData("EmployedPT");
        }
    }
}
