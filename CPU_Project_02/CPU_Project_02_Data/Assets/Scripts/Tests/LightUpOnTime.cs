using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using System.Xml;

public class LightUpOnTime : MonoBehaviour {

	//time control
	[Range (0,24)]
	public Slider timeSlider;
	public Text hour;
	public Text minutes;
	public DateTime currentTime = DateTime.Now;

	public String hrs;
	public String min;

	public float timeCount;
	public int hourIncrement;
	public int minIncrement;

	//objects
	public GameObject cube;
	public GameObject cube1;
	public GameObject cube2;

	//light controls
	public float duration = 1.0F;
	private Light lt;

	//xml
	public TextAsset gisDataFile;


	void Start() {
		
		lt = cube.GetComponent<Light>();
	

		LightFlash ();



	}

	void Update() {

		hourIncrement++;
		Debug.Log (hourIncrement);

		timeCount += Mathf.Round(Time.deltaTime);
		Debug.Log (timeCount);

		//DateTime.Parse

		int minIncrement = currentTime.Minute;
		//Debug.Log (minIncrement);

		String hrs = currentTime.Hour.ToString ();
		String min = currentTime.Minute.ToString ();

		hour.text = hrs;
		minutes.text = min;




		float phi = Time.time / duration * 2 * Mathf.PI;
		float amplitude = Mathf.Cos(phi) * 0.5F + 0.5F;
		lt.intensity = amplitude;

	}


	private IEnumerator coroutine(XmlNodeList nodeList, string Switcher)
	{
		foreach (XmlNode xmlNodeI in nodeList)
		{
			//wait 1 frame before adding a cylinder
			yield return new WaitForEndOfFrame();

			//Assign variables from xml too c# vars

			//DateTime.Parse
			float time = float.Parse(xmlNodeI["time1"].InnerText);
			string name = xmlNodeI ["name"].InnerText;
			Debug.Log(time);

			//this checks the time against scanned value
			currentTime = DateTime.Now;
			if (currentTime == DateTime.Now) {
				Debug.Log ("how soon is now");

			}


//			GameObject cylinder = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
//			cylinder.name = xmlNodeI["name"].InnerText;
		}
		yield break;
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


	void LightFlash (){
//		float phi = Time.time / duration * 5 * Mathf.PI;
//		float amplitude = Mathf.Cos(phi) * 0.5F + 0.5F;
//		lt.intensity = amplitude*10;
		ReadGISData("time1");
	}




}
