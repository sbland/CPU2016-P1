using UnityEngine;
using System.Collections;
using System.IO;
using System.Xml;
using System;
using System.Collections.Generic;

public class ReadDataXML : MonoBehaviour {

    public string filePath;

    public int valueOut;

   

    // Use this for initialization
    void Start () {
        
        ReadXMLData();

    
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ReadXMLData()
    {
       


        Debug.Log("TEST");

        XmlDocument newXml = new XmlDocument();

        try { newXml.Load(filePath); }
        catch { Debug.Log("Failed to load file"); }

        XmlNodeList stopList = newXml.DocumentElement.ChildNodes;

        //Debug.Log(stopList[0].InnerXml);
        //Debug.Log(stopList[1].InnerXml);

        XmlNode Bury = stopList[0];


        //int timeAVal = (int) Bury["TimeA"].NodeType;
        Debug.Log(Bury["Location"].InnerText);

        //valueOut = Bury["TimeA"];

        //Debug.Log((int)Bury["TimeA"].InnerText);

        //Debug.Log(nodeList[0].Name + " - " + nodeList[0].InnerText);
        //Debug.Log(nodeList[1].Name + " - " + nodeList[1].InnerText);




    }
}
