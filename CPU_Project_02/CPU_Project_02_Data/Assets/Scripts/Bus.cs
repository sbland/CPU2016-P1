using UnityEngine;
using System.Collections;
using System.IO;
using System.Xml;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine.UI;


public class Bus : MonoBehaviour
{
    public float scale = 400;
    public float offsetX = 397000;
    public float offsetY = 395000;

	public Button bus;


	private GameObject cylinder;

    public TextAsset gisDataFile;


    // Use this for initialization
    void Start()
    {
		//this is the switcher button
		Button btn1 = bus.GetComponent<Button>();
		btn1.onClick.AddListener(TaskOnClick1);

        //ReadGISData();
    }

    // Update is called once per frame
    void Update()
    {

    }
		
	private IEnumerator coroutine(XmlNodeList nodeList,  string Switcher)
	{
		foreach (XmlNode xmlNodeI in nodeList)
		{
			//wait 1 frame before adding a cylinder
			yield return new WaitForEndOfFrame();

			//Assign variables from xml too c# vars
			float gisZ = float.Parse(xmlNodeI["X"].InnerText);
			float gisX = float.Parse(xmlNodeI["Y"].InnerText);
			string gisStudents = xmlNodeI["name"].InnerText;

			float gisGeneric = 1f;


			//offset and rescale
			gisX = gisX - offsetX;
			gisZ = gisZ - offsetY;

			gisX = gisX / scale;
			gisZ = gisZ / scale;

			float inverseScale = 500 / scale;


			GameObject cylinder = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
			cylinder.name = xmlNodeI["name"].InnerText;
			cylinder.transform.position = new Vector3(-gisX, gisGeneric, gisZ);
			cylinder.transform.localScale = new Vector3(inverseScale, gisGeneric, inverseScale);
			cylinder.tag = "Bars"; 
		}
		yield break;

	}


	void TaskOnClick1(){


		GameObject[] names = GameObject.FindGameObjectsWithTag("Bars");

		foreach(GameObject item in names)
		{
			Destroy(item);
		}

		ReadGISData("name");

		}
		
	public void ReadGISData(string InputText)
	{


		XmlDocument gisXml = new XmlDocument();

		//try { gisXml.Load(gisData.text); }
		//catch { Debug.Log("Failed to load file"); }

		gisXml.LoadXml(gisDataFile.text);

		XmlNodeList oaPointList = gisXml.DocumentElement.ChildNodes;

		StartCoroutine(coroutine(oaPointList, InputText));

	}
		
}
