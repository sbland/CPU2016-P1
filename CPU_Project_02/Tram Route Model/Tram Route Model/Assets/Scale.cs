using UnityEngine;
using UnityEngine.UI;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;
using System.Linq;



public class Scale : MonoBehaviour {

	public GameObject scalableBar;

	//public Slider timeSlider;
	//[Range (0, 6)] public int time = 0;
	public Button button1;
	public Button button2;
	public Button button3;
	public Button button4;
	public Button button5;
	public Button button6;

	public int numVal1;
	public int numVal2;
	public int numVal3;
	public int numVal4;
	public int numVal5;
	public int numVal6;

	public string location;
	public int timeA;
	public int timeB;
	public int timeC;
	public int timeD;
	public int timeE;
	public int timeF;

	public string filePathAltrincham;
	public string xmlDataAltrincham;

	public string filePathAshton;
	public string xmlDataAshton;

	public string filePathBury;
	public string xmlDataBury;

	public string filePathCityCentre;
	public string xmlDataCityCentre;

	public string filePathEastDidsbury;
	public string xmlDataEastDidsbury;

	public string filePathEccles;
	public string xmlDataEccles;

	public string filePathRochdale;
	public string xmlDataRochdale;







	//public TextAsset GameAsset;
	//List<Dictionary<string,string>> tramInOutValues = new List<Dictionary<string,string>>();
	//Dictionary<string,string> obj;




	//BUTTON RESPONSES
	void Start () {
		
		Button btn1 = button1.GetComponent<Button>();
		btn1.onClick.AddListener(TaskOnClick1);

		Button btn2 = button2.GetComponent<Button>();
		btn2.onClick.AddListener(TaskOnClick2);

		Button btn3 = button3.GetComponent<Button>();
		btn3.onClick.AddListener(TaskOnClick3);

		Button btn4 = button4.GetComponent<Button>();
		btn4.onClick.AddListener(TaskOnClick4);

		Button btn5 = button5.GetComponent<Button>();
		btn5.onClick.AddListener(TaskOnClick5);

		Button btn6 = button6.GetComponent<Button>();
		btn6.onClick.AddListener(TaskOnClick6);


		//GetXmlData ();


		ReadXMLDataAltrincham();
		ReadXMLDataAshton();
		ReadXMLDataBury();
		ReadXMLDataCityCentre();
		ReadXMLDataEccles();
		ReadXMLDataEastDidsbury();
		ReadXMLDataRochdale();


		transform.localScale = new Vector3(100, 100, 100);

	}


	//THIS IS WHERE WE READ THE XML Altrincham
	public void ReadXMLDataAltrincham(){
		XmlDocument newXml = new XmlDocument();

		try { newXml.Load(filePathAltrincham); }
		catch { Debug.Log("Failed to load file"); }

		XmlNodeList stopList = newXml.DocumentElement.ChildNodes;


		// these are the stops
		XmlNode Altrincham = stopList[0];


		XmlNode NavigationRoad = stopList[1];


		XmlNode Timperley = stopList[2];


		XmlNode Brooklands = stopList[3];


		XmlNode Sale = stopList[4];


		XmlNode DaneRoad = stopList[5];


		XmlNode Stretford = stopList[6];


		XmlNode OldTrafford = stopList[7];

		XmlNode TraffordBar = stopList[8];

		XmlNode Cornbrook = stopList[9];




		//THIS IS THE SWITCHER

		if (gameObject.tag == "Altrincham") {
			numVal1 = Int32.Parse(Altrincham["TimeA"].InnerText);
			numVal2 = Int32.Parse(Altrincham["TimeB"].InnerText);
			numVal3 = Int32.Parse(Altrincham["TimeC"].InnerText);
			numVal4 = Int32.Parse(Altrincham["TimeD"].InnerText);
			numVal5 = Int32.Parse(Altrincham["TimeE"].InnerText);
			numVal6 = Int32.Parse(Altrincham["TimeF"].InnerText);

		}

		if (gameObject.tag == "NavigationRoad") {
			numVal1 = Int32.Parse(NavigationRoad["TimeA"].InnerText);
			numVal2 = Int32.Parse(NavigationRoad["TimeB"].InnerText);
			numVal3 = Int32.Parse(NavigationRoad["TimeC"].InnerText);
			numVal4 = Int32.Parse(NavigationRoad["TimeD"].InnerText);
			numVal5 = Int32.Parse(NavigationRoad["TimeE"].InnerText);
			numVal6 = Int32.Parse(NavigationRoad["TimeF"].InnerText);

		}

		if (gameObject.tag == "Timperley") {
			numVal1 = Int32.Parse(Timperley["TimeA"].InnerText);
			numVal2 = Int32.Parse(Timperley["TimeB"].InnerText);
			numVal3 = Int32.Parse(Timperley["TimeC"].InnerText);
			numVal4 = Int32.Parse(Timperley["TimeD"].InnerText);
			numVal5 = Int32.Parse(Timperley["TimeE"].InnerText);
			numVal6 = Int32.Parse(Timperley["TimeF"].InnerText);

		}

		if (gameObject.tag == "Brooklands") {
			numVal1 = Int32.Parse(Brooklands["TimeA"].InnerText);
			numVal2 = Int32.Parse(Brooklands["TimeB"].InnerText);
			numVal3 = Int32.Parse(Brooklands["TimeC"].InnerText);
			numVal4 = Int32.Parse(Brooklands["TimeD"].InnerText);
			numVal5 = Int32.Parse(Brooklands["TimeE"].InnerText);
			numVal6 = Int32.Parse(Brooklands["TimeF"].InnerText);

		}

		if (gameObject.tag == "Sale") {
			numVal1 = Int32.Parse(Sale["TimeA"].InnerText);
			numVal2 = Int32.Parse(Sale["TimeB"].InnerText);
			numVal3 = Int32.Parse(Sale["TimeC"].InnerText);
			numVal4 = Int32.Parse(Sale["TimeD"].InnerText);
			numVal5 = Int32.Parse(Sale["TimeE"].InnerText);
			numVal6 = Int32.Parse(Sale["TimeF"].InnerText);

		}

		if (gameObject.tag == "DaneRoad") {
			numVal1 = Int32.Parse(DaneRoad["TimeA"].InnerText);
			numVal2 = Int32.Parse(DaneRoad["TimeB"].InnerText);
			numVal3 = Int32.Parse(DaneRoad["TimeC"].InnerText);
			numVal4 = Int32.Parse(DaneRoad["TimeD"].InnerText);
			numVal5 = Int32.Parse(DaneRoad["TimeE"].InnerText);
			numVal6 = Int32.Parse(DaneRoad["TimeF"].InnerText);

		}

		if (gameObject.tag == "Stretford") {
			numVal1 = Int32.Parse(Stretford["TimeA"].InnerText);
			numVal2 = Int32.Parse(Stretford["TimeB"].InnerText);
			numVal3 = Int32.Parse(Stretford["TimeC"].InnerText);
			numVal4 = Int32.Parse(Stretford["TimeD"].InnerText);
			numVal5 = Int32.Parse(Stretford["TimeE"].InnerText);
			numVal6 = Int32.Parse(Stretford["TimeF"].InnerText);

		}

		if (gameObject.tag == "OldTrafford") {
			numVal1 = Int32.Parse(OldTrafford["TimeA"].InnerText);
			numVal2 = Int32.Parse(OldTrafford["TimeB"].InnerText);
			numVal3 = Int32.Parse(OldTrafford["TimeC"].InnerText);
			numVal4 = Int32.Parse(OldTrafford["TimeD"].InnerText);
			numVal5 = Int32.Parse(OldTrafford["TimeE"].InnerText);
			numVal6 = Int32.Parse(OldTrafford["TimeF"].InnerText);

		}

		if (gameObject.tag == "TraffordBar") {
			numVal1 = Int32.Parse(TraffordBar["TimeA"].InnerText);
			numVal2 = Int32.Parse(TraffordBar["TimeB"].InnerText);
			numVal3 = Int32.Parse(TraffordBar["TimeC"].InnerText);
			numVal4 = Int32.Parse(TraffordBar["TimeD"].InnerText);
			numVal5 = Int32.Parse(TraffordBar["TimeE"].InnerText);
			numVal6 = Int32.Parse(TraffordBar["TimeF"].InnerText);

		}

		if (gameObject.tag == "Cornbrook") {
			numVal1 = Int32.Parse(Cornbrook["TimeA"].InnerText);
			numVal2 = Int32.Parse(Cornbrook["TimeB"].InnerText);
			numVal3 = Int32.Parse(Cornbrook["TimeC"].InnerText);
			numVal4 = Int32.Parse(Cornbrook["TimeD"].InnerText);
			numVal5 = Int32.Parse(Cornbrook["TimeE"].InnerText);
			numVal6 = Int32.Parse(Cornbrook["TimeF"].InnerText);
		
		}

		//THIS IS THE END OF READ XML ALTRINCHAM
	}



	//THIS IS WHERE WE READ THE XML AshtonunderLyne
	public void ReadXMLDataAshton(){
		XmlDocument newXml = new XmlDocument();

		try { newXml.Load(filePathAshton); }
		catch { Debug.Log("Failed to load file"); }

		XmlNodeList stopList = newXml.DocumentElement.ChildNodes;


		// these are the stops
		XmlNode AshtonunderLyne = stopList[0];


		XmlNode AshtonWest = stopList[1];
	

		XmlNode AshtonMoss = stopList[2];


		XmlNode Audenshaw = stopList[3];


		XmlNode Droylsden = stopList[4];


		XmlNode CemeteryRoad = stopList[5];


		XmlNode EdgeLane = stopList[6];


		XmlNode ClaytonHall = stopList[7];


		XmlNode Velopark = stopList[8];
	

		XmlNode EtihadCampus = stopList[9];
	

		XmlNode HoltTown = stopList[10];
	

		XmlNode NewIslington = stopList[11];
	


		//THIS IS THE SWITCHER

		if (gameObject.tag == "AshtonunderLyne") {
			numVal1 = Int32.Parse(AshtonunderLyne["TimeA"].InnerText);
			numVal2 = Int32.Parse(AshtonunderLyne["TimeB"].InnerText);
			numVal3 = Int32.Parse(AshtonunderLyne["TimeC"].InnerText);
			numVal4 = Int32.Parse(AshtonunderLyne["TimeD"].InnerText);
			numVal5 = Int32.Parse(AshtonunderLyne["TimeE"].InnerText);
			numVal6 = Int32.Parse(AshtonunderLyne["TimeF"].InnerText);

		}

		if (gameObject.tag == "AshtonWest") {
			numVal1 = Int32.Parse(AshtonWest["TimeA"].InnerText);
			numVal2 = Int32.Parse(AshtonWest["TimeB"].InnerText);
			numVal3 = Int32.Parse(AshtonWest["TimeC"].InnerText);
			numVal4 = Int32.Parse(AshtonWest["TimeD"].InnerText);
			numVal5 = Int32.Parse(AshtonWest["TimeE"].InnerText);
			numVal6 = Int32.Parse(AshtonWest["TimeF"].InnerText);
	
		}

		if (gameObject.tag == "AshtonMoss") {
			numVal1 = Int32.Parse(AshtonMoss["TimeA"].InnerText);
			numVal2 = Int32.Parse(AshtonMoss["TimeB"].InnerText);
			numVal3 = Int32.Parse(AshtonMoss["TimeC"].InnerText);
			numVal4 = Int32.Parse(AshtonMoss["TimeD"].InnerText);
			numVal5 = Int32.Parse(AshtonMoss["TimeE"].InnerText);
			numVal6 = Int32.Parse(AshtonMoss["TimeF"].InnerText);
	
		}

		if (gameObject.tag == "Audenshaw") {
			numVal1 = Int32.Parse(Audenshaw["TimeA"].InnerText);
			numVal2 = Int32.Parse(Audenshaw["TimeB"].InnerText);
			numVal3 = Int32.Parse(Audenshaw["TimeC"].InnerText);
			numVal4 = Int32.Parse(Audenshaw["TimeD"].InnerText);
			numVal5 = Int32.Parse(Audenshaw["TimeE"].InnerText);
			numVal6 = Int32.Parse(Audenshaw["TimeF"].InnerText);

		}

		if (gameObject.tag == "Droylsden") {
			numVal1 = Int32.Parse(Droylsden["TimeA"].InnerText);
			numVal2 = Int32.Parse(Droylsden["TimeB"].InnerText);
			numVal3 = Int32.Parse(Droylsden["TimeC"].InnerText);
			numVal4 = Int32.Parse(Droylsden["TimeD"].InnerText);
			numVal5 = Int32.Parse(Droylsden["TimeE"].InnerText);
			numVal6 = Int32.Parse(Droylsden["TimeF"].InnerText);
	
		}

		if (gameObject.tag == "CemeteryRoad") {
			numVal1 = Int32.Parse(CemeteryRoad["TimeA"].InnerText);
			numVal2 = Int32.Parse(CemeteryRoad["TimeB"].InnerText);
			numVal3 = Int32.Parse(CemeteryRoad["TimeC"].InnerText);
			numVal4 = Int32.Parse(CemeteryRoad["TimeD"].InnerText);
			numVal5 = Int32.Parse(CemeteryRoad["TimeE"].InnerText);
			numVal6 = Int32.Parse(CemeteryRoad["TimeF"].InnerText);
		
		}

		if (gameObject.tag == "EdgeLane") {
			numVal1 = Int32.Parse(EdgeLane["TimeA"].InnerText);
			numVal2 = Int32.Parse(EdgeLane["TimeB"].InnerText);
			numVal3 = Int32.Parse(EdgeLane["TimeC"].InnerText);
			numVal4 = Int32.Parse(EdgeLane["TimeD"].InnerText);
			numVal5 = Int32.Parse(EdgeLane["TimeE"].InnerText);
			numVal6 = Int32.Parse(EdgeLane["TimeF"].InnerText);
	
		}

		if (gameObject.tag == "ClaytonHall") {
			numVal1 = Int32.Parse(ClaytonHall["TimeA"].InnerText);
			numVal2 = Int32.Parse(ClaytonHall["TimeB"].InnerText);
			numVal3 = Int32.Parse(ClaytonHall["TimeC"].InnerText);
			numVal4 = Int32.Parse(ClaytonHall["TimeD"].InnerText);
			numVal5 = Int32.Parse(ClaytonHall["TimeE"].InnerText);
			numVal6 = Int32.Parse(ClaytonHall["TimeF"].InnerText);
		
		}

		if (gameObject.tag == "Velopark") {
			numVal1 = Int32.Parse(Velopark["TimeA"].InnerText);
			numVal2 = Int32.Parse(Velopark["TimeB"].InnerText);
			numVal3 = Int32.Parse(Velopark["TimeC"].InnerText);
			numVal4 = Int32.Parse(Velopark["TimeD"].InnerText);
			numVal5 = Int32.Parse(Velopark["TimeE"].InnerText);
			numVal6 = Int32.Parse(Velopark["TimeF"].InnerText);
	
		}

		if (gameObject.tag == "EtihadCampus") {
			numVal1 = Int32.Parse(EtihadCampus["TimeA"].InnerText);
			numVal2 = Int32.Parse(EtihadCampus["TimeB"].InnerText);
			numVal3 = Int32.Parse(EtihadCampus["TimeC"].InnerText);
			numVal4 = Int32.Parse(EtihadCampus["TimeD"].InnerText);
			numVal5 = Int32.Parse(EtihadCampus["TimeE"].InnerText);
			numVal6 = Int32.Parse(EtihadCampus["TimeF"].InnerText);
		
		}


		if (gameObject.tag == "HoltTown") {
			numVal1 = Int32.Parse(HoltTown["TimeA"].InnerText);
			numVal2 = Int32.Parse(HoltTown["TimeB"].InnerText);
			numVal3 = Int32.Parse(HoltTown["TimeC"].InnerText);
			numVal4 = Int32.Parse(HoltTown["TimeD"].InnerText);
			numVal5 = Int32.Parse(HoltTown["TimeE"].InnerText);
			numVal6 = Int32.Parse(HoltTown["TimeF"].InnerText);
		
		}



		if (gameObject.tag == "NewIslington") {
			numVal1 = Int32.Parse(NewIslington["TimeA"].InnerText);
			numVal2 = Int32.Parse(NewIslington["TimeB"].InnerText);
			numVal3 = Int32.Parse(NewIslington["TimeC"].InnerText);
			numVal4 = Int32.Parse(NewIslington["TimeD"].InnerText);
			numVal5 = Int32.Parse(NewIslington["TimeE"].InnerText);
			numVal6 = Int32.Parse(NewIslington["TimeF"].InnerText);

		}

		//THIS IS THE END OF READ XML ASHTON
	}


	//THIS IS WHERE WE READ THE XML bury
	public void ReadXMLDataBury(){
		XmlDocument newXml = new XmlDocument();

		try { newXml.Load(filePathBury); }
		catch { Debug.Log("Failed to load file"); }

		XmlNodeList stopList = newXml.DocumentElement.ChildNodes;


		// these are the stops
		XmlNode Bury = stopList[0];


		XmlNode Radcliffe = stopList[1];


		XmlNode Whitefield = stopList[2];
	

		XmlNode BessesOthBarn = stopList[3];
	

		XmlNode Prestwich = stopList[4];


		XmlNode HeatonPark = stopList[5];
	

		XmlNode BowkerVale = stopList[6];


		XmlNode Crumpsall = stopList[7];

		XmlNode AbrahamMoss = stopList[8];
	

		XmlNode QueensRoad = stopList[9];




		//THIS IS THE SWITCHER

		if (gameObject.tag == "Bury") {
			numVal1 = Int32.Parse(Bury["TimeA"].InnerText);
			numVal2 = Int32.Parse(Bury["TimeB"].InnerText);
			numVal3 = Int32.Parse(Bury["TimeC"].InnerText);
			numVal4 = Int32.Parse(Bury["TimeD"].InnerText);
			numVal5 = Int32.Parse(Bury["TimeE"].InnerText);
			numVal6 = Int32.Parse(Bury["TimeF"].InnerText);
	
		}

		if (gameObject.tag == "Radcliffe") {
			numVal1 = Int32.Parse(Radcliffe["TimeA"].InnerText);
			numVal2 = Int32.Parse(Radcliffe["TimeB"].InnerText);
			numVal3 = Int32.Parse(Radcliffe["TimeC"].InnerText);
			numVal4 = Int32.Parse(Radcliffe["TimeD"].InnerText);
			numVal5 = Int32.Parse(Radcliffe["TimeE"].InnerText);
			numVal6 = Int32.Parse(Radcliffe["TimeF"].InnerText);
		
		}

		if (gameObject.tag == "Whitefield") {
			numVal1 = Int32.Parse(Whitefield["TimeA"].InnerText);
			numVal2 = Int32.Parse(Whitefield["TimeB"].InnerText);
			numVal3 = Int32.Parse(Whitefield["TimeC"].InnerText);
			numVal4 = Int32.Parse(Whitefield["TimeD"].InnerText);
			numVal5 = Int32.Parse(Whitefield["TimeE"].InnerText);
			numVal6 = Int32.Parse(Whitefield["TimeF"].InnerText);
		
		}

		if (gameObject.tag == "BessesOthBarn") {
			numVal1 = Int32.Parse(BessesOthBarn["TimeA"].InnerText);
			numVal2 = Int32.Parse(BessesOthBarn["TimeB"].InnerText);
			numVal3 = Int32.Parse(BessesOthBarn["TimeC"].InnerText);
			numVal4 = Int32.Parse(BessesOthBarn["TimeD"].InnerText);
			numVal5 = Int32.Parse(BessesOthBarn["TimeE"].InnerText);
			numVal6 = Int32.Parse(BessesOthBarn["TimeF"].InnerText);

		}

		if (gameObject.tag == "Prestwich") {
			numVal1 = Int32.Parse(Prestwich["TimeA"].InnerText);
			numVal2 = Int32.Parse(Prestwich["TimeB"].InnerText);
			numVal3 = Int32.Parse(Prestwich["TimeC"].InnerText);
			numVal4 = Int32.Parse(Prestwich["TimeD"].InnerText);
			numVal5 = Int32.Parse(Prestwich["TimeE"].InnerText);
			numVal6 = Int32.Parse(Prestwich["TimeF"].InnerText);
		
		}

		if (gameObject.tag == "HeatonPark") {
			numVal1 = Int32.Parse(HeatonPark["TimeA"].InnerText);
			numVal2 = Int32.Parse(HeatonPark["TimeB"].InnerText);
			numVal3 = Int32.Parse(HeatonPark["TimeC"].InnerText);
			numVal4 = Int32.Parse(HeatonPark["TimeD"].InnerText);
			numVal5 = Int32.Parse(HeatonPark["TimeE"].InnerText);
			numVal6 = Int32.Parse(HeatonPark["TimeF"].InnerText);

		}

		if (gameObject.tag == "BowkerVale") {
			numVal1 = Int32.Parse(BowkerVale["TimeA"].InnerText);
			numVal2 = Int32.Parse(BowkerVale["TimeB"].InnerText);
			numVal3 = Int32.Parse(BowkerVale["TimeC"].InnerText);
			numVal4 = Int32.Parse(BowkerVale["TimeD"].InnerText);
			numVal5 = Int32.Parse(BowkerVale["TimeE"].InnerText);
			numVal6 = Int32.Parse(BowkerVale["TimeF"].InnerText);
		
		}

		if (gameObject.tag == "Crumpsall") {
			numVal1 = Int32.Parse(Crumpsall["TimeA"].InnerText);
			numVal2 = Int32.Parse(Crumpsall["TimeB"].InnerText);
			numVal3 = Int32.Parse(Crumpsall["TimeC"].InnerText);
			numVal4 = Int32.Parse(Crumpsall["TimeD"].InnerText);
			numVal5 = Int32.Parse(Crumpsall["TimeE"].InnerText);
			numVal6 = Int32.Parse(Crumpsall["TimeF"].InnerText);
	
		}

		if (gameObject.tag == "AbrahamMoss") {
			numVal1 = Int32.Parse(AbrahamMoss["TimeA"].InnerText);
			numVal2 = Int32.Parse(AbrahamMoss["TimeB"].InnerText);
			numVal3 = Int32.Parse(AbrahamMoss["TimeC"].InnerText);
			numVal4 = Int32.Parse(AbrahamMoss["TimeD"].InnerText);
			numVal5 = Int32.Parse(AbrahamMoss["TimeE"].InnerText);
			numVal6 = Int32.Parse(AbrahamMoss["TimeF"].InnerText);
	
		}

		if (gameObject.tag == "QueensRoad") {
			numVal1 = Int32.Parse(QueensRoad["TimeA"].InnerText);
			numVal2 = Int32.Parse(QueensRoad["TimeB"].InnerText);
			numVal3 = Int32.Parse(QueensRoad["TimeC"].InnerText);
			numVal4 = Int32.Parse(QueensRoad["TimeD"].InnerText);
			numVal5 = Int32.Parse(QueensRoad["TimeE"].InnerText);
			numVal6 = Int32.Parse(QueensRoad["TimeF"].InnerText);
	
		}

		//THIS IS THE END OF READ XML BURY
	}





	//THIS IS WHERE WE READ THE XML CityCentre
	public void ReadXMLDataCityCentre(){
		XmlDocument newXml = new XmlDocument();

		try { newXml.Load(filePathCityCentre); }
		catch { Debug.Log("Failed to load file"); }

		XmlNodeList stopList = newXml.DocumentElement.ChildNodes;


		// these are the stops
		XmlNode DeansgateCastlefield = stopList[0];


		XmlNode StPetersSquare = stopList[1];


		XmlNode PiccadillyGardens = stopList[2];
	
		XmlNode MarketStreet = stopList[3];

		XmlNode Shudehill = stopList[4];

		XmlNode CemeteryRoad = stopList[5];

		XmlNode Victoria = stopList[6];



		//THIS IS THE SWITCHER

		if (gameObject.tag == "DeansgateCastlefield") {
			numVal1 = Int32.Parse(DeansgateCastlefield["TimeA"].InnerText);
			numVal2 = Int32.Parse(DeansgateCastlefield["TimeB"].InnerText);
			numVal3 = Int32.Parse(DeansgateCastlefield["TimeC"].InnerText);
			numVal4 = Int32.Parse(DeansgateCastlefield["TimeD"].InnerText);
			numVal5 = Int32.Parse(DeansgateCastlefield["TimeE"].InnerText);
			numVal6 = Int32.Parse(DeansgateCastlefield["TimeF"].InnerText);

		}

		if (gameObject.tag == "StPetersSquare") {
			numVal1 = Int32.Parse(StPetersSquare["TimeA"].InnerText);
			numVal2 = Int32.Parse(StPetersSquare["TimeB"].InnerText);
			numVal3 = Int32.Parse(StPetersSquare["TimeC"].InnerText);
			numVal4 = Int32.Parse(StPetersSquare["TimeD"].InnerText);
			numVal5 = Int32.Parse(StPetersSquare["TimeE"].InnerText);
			numVal6 = Int32.Parse(StPetersSquare["TimeF"].InnerText);

		}

		if (gameObject.tag == "PiccadillyGardens") {
			numVal1 = Int32.Parse(PiccadillyGardens["TimeA"].InnerText);
			numVal2 = Int32.Parse(PiccadillyGardens["TimeB"].InnerText);
			numVal3 = Int32.Parse(PiccadillyGardens["TimeC"].InnerText);
			numVal4 = Int32.Parse(PiccadillyGardens["TimeD"].InnerText);
			numVal5 = Int32.Parse(PiccadillyGardens["TimeE"].InnerText);
			numVal6 = Int32.Parse(PiccadillyGardens["TimeF"].InnerText);

		}

		if (gameObject.tag == "MarketStreet") {
			numVal1 = Int32.Parse(MarketStreet["TimeA"].InnerText);
			numVal2 = Int32.Parse(MarketStreet["TimeB"].InnerText);
			numVal3 = Int32.Parse(MarketStreet["TimeC"].InnerText);
			numVal4 = Int32.Parse(MarketStreet["TimeD"].InnerText);
			numVal5 = Int32.Parse(MarketStreet["TimeE"].InnerText);
			numVal6 = Int32.Parse(MarketStreet["TimeF"].InnerText);

		}

		if (gameObject.tag == "Shudehill") {
			numVal1 = Int32.Parse(Shudehill["TimeA"].InnerText);
			numVal2 = Int32.Parse(Shudehill["TimeB"].InnerText);
			numVal3 = Int32.Parse(Shudehill["TimeC"].InnerText);
			numVal4 = Int32.Parse(Shudehill["TimeD"].InnerText);
			numVal5 = Int32.Parse(Shudehill["TimeE"].InnerText);
			numVal6 = Int32.Parse(Shudehill["TimeF"].InnerText);

		}

		if (gameObject.tag == "CemeteryRoad") {
			numVal1 = Int32.Parse(CemeteryRoad["TimeA"].InnerText);
			numVal2 = Int32.Parse(CemeteryRoad["TimeB"].InnerText);
			numVal3 = Int32.Parse(CemeteryRoad["TimeC"].InnerText);
			numVal4 = Int32.Parse(CemeteryRoad["TimeD"].InnerText);
			numVal5 = Int32.Parse(CemeteryRoad["TimeE"].InnerText);
			numVal6 = Int32.Parse(CemeteryRoad["TimeF"].InnerText);

		}

		if (gameObject.tag == "Victoria") {
			numVal1 = Int32.Parse(Victoria["TimeA"].InnerText);
			numVal2 = Int32.Parse(Victoria["TimeB"].InnerText);
			numVal3 = Int32.Parse(Victoria["TimeC"].InnerText);
			numVal4 = Int32.Parse(Victoria["TimeD"].InnerText);
			numVal5 = Int32.Parse(Victoria["TimeE"].InnerText);
			numVal6 = Int32.Parse(Victoria["TimeF"].InnerText);

		}


		//THIS IS THE END OF READ XML CITYCENTRE
	}



	//THIS IS WHERE WE READ THE XML Eccles
	public void ReadXMLDataEccles(){
		XmlDocument newXml = new XmlDocument();

		try { newXml.Load(filePathEccles); }
		catch { Debug.Log("Failed to load file"); }

		XmlNodeList stopList = newXml.DocumentElement.ChildNodes;


		// these are the stops
		XmlNode Eccles = stopList[0];

		XmlNode Ladywell = stopList[1];

		XmlNode Weaste = stopList[2];

		XmlNode Langworthy = stopList[3];

		XmlNode Broadway = stopList[4];

		XmlNode HarbourCity = stopList[5];

		XmlNode Anchorage = stopList[6];

		XmlNode SalfordQuays = stopList[7];

		XmlNode ExchangeQuay = stopList[8];

		XmlNode Pomona = stopList[9];

		XmlNode MediaCityUK = stopList[10];



		//THIS IS THE SWITCHER

		if (gameObject.tag == "Eccles") {
			numVal1 = Int32.Parse(Eccles["TimeA"].InnerText);
			numVal2 = Int32.Parse(Eccles["TimeB"].InnerText);
			numVal3 = Int32.Parse(Eccles["TimeC"].InnerText);
			numVal4 = Int32.Parse(Eccles["TimeD"].InnerText);
			numVal5 = Int32.Parse(Eccles["TimeE"].InnerText);
			numVal6 = Int32.Parse(Eccles["TimeF"].InnerText);

		}

		if (gameObject.tag == "Ladywell") {
			numVal1 = Int32.Parse(Ladywell["TimeA"].InnerText);
			numVal2 = Int32.Parse(Ladywell["TimeB"].InnerText);
			numVal3 = Int32.Parse(Ladywell["TimeC"].InnerText);
			numVal4 = Int32.Parse(Ladywell["TimeD"].InnerText);
			numVal5 = Int32.Parse(Ladywell["TimeE"].InnerText);
			numVal6 = Int32.Parse(Ladywell["TimeF"].InnerText);

		}

		if (gameObject.tag == "Weaste") {
			numVal1 = Int32.Parse(Weaste["TimeA"].InnerText);
			numVal2 = Int32.Parse(Weaste["TimeB"].InnerText);
			numVal3 = Int32.Parse(Weaste["TimeC"].InnerText);
			numVal4 = Int32.Parse(Weaste["TimeD"].InnerText);
			numVal5 = Int32.Parse(Weaste["TimeE"].InnerText);
			numVal6 = Int32.Parse(Weaste["TimeF"].InnerText);

		}

		if (gameObject.tag == "Langworthy") {
			numVal1 = Int32.Parse(Langworthy["TimeA"].InnerText);
			numVal2 = Int32.Parse(Langworthy["TimeB"].InnerText);
			numVal3 = Int32.Parse(Langworthy["TimeC"].InnerText);
			numVal4 = Int32.Parse(Langworthy["TimeD"].InnerText);
			numVal5 = Int32.Parse(Langworthy["TimeE"].InnerText);
			numVal6 = Int32.Parse(Langworthy["TimeF"].InnerText);

		}

		if (gameObject.tag == "Broadway") {
			numVal1 = Int32.Parse(Broadway["TimeA"].InnerText);
			numVal2 = Int32.Parse(Broadway["TimeB"].InnerText);
			numVal3 = Int32.Parse(Broadway["TimeC"].InnerText);
			numVal4 = Int32.Parse(Broadway["TimeD"].InnerText);
			numVal5 = Int32.Parse(Broadway["TimeE"].InnerText);
			numVal6 = Int32.Parse(Broadway["TimeF"].InnerText);

		}

		if (gameObject.tag == "HarbourCity") {
			numVal1 = Int32.Parse(HarbourCity["TimeA"].InnerText);
			numVal2 = Int32.Parse(HarbourCity["TimeB"].InnerText);
			numVal3 = Int32.Parse(HarbourCity["TimeC"].InnerText);
			numVal4 = Int32.Parse(HarbourCity["TimeD"].InnerText);
			numVal5 = Int32.Parse(HarbourCity["TimeE"].InnerText);
			numVal6 = Int32.Parse(HarbourCity["TimeF"].InnerText);

		}

		if (gameObject.tag == "Anchorage") {
			numVal1 = Int32.Parse(Anchorage["TimeA"].InnerText);
			numVal2 = Int32.Parse(Anchorage["TimeB"].InnerText);
			numVal3 = Int32.Parse(Anchorage["TimeC"].InnerText);
			numVal4 = Int32.Parse(Anchorage["TimeD"].InnerText);
			numVal5 = Int32.Parse(Anchorage["TimeE"].InnerText);
			numVal6 = Int32.Parse(Anchorage["TimeF"].InnerText);

		}

		if (gameObject.tag == "SalfordQuays") {
			numVal1 = Int32.Parse(SalfordQuays["TimeA"].InnerText);
			numVal2 = Int32.Parse(SalfordQuays["TimeB"].InnerText);
			numVal3 = Int32.Parse(SalfordQuays["TimeC"].InnerText);
			numVal4 = Int32.Parse(SalfordQuays["TimeD"].InnerText);
			numVal5 = Int32.Parse(SalfordQuays["TimeE"].InnerText);
			numVal6 = Int32.Parse(SalfordQuays["TimeF"].InnerText);

		}

		if (gameObject.tag == "ExchangeQuay") {
			numVal1 = Int32.Parse(ExchangeQuay["TimeA"].InnerText);
			numVal2 = Int32.Parse(ExchangeQuay["TimeB"].InnerText);
			numVal3 = Int32.Parse(ExchangeQuay["TimeC"].InnerText);
			numVal4 = Int32.Parse(ExchangeQuay["TimeD"].InnerText);
			numVal5 = Int32.Parse(ExchangeQuay["TimeE"].InnerText);
			numVal6 = Int32.Parse(ExchangeQuay["TimeF"].InnerText);

		}

		if (gameObject.tag == "Pomona") {
			numVal1 = Int32.Parse(Pomona["TimeA"].InnerText);
			numVal2 = Int32.Parse(Pomona["TimeB"].InnerText);
			numVal3 = Int32.Parse(Pomona["TimeC"].InnerText);
			numVal4 = Int32.Parse(Pomona["TimeD"].InnerText);
			numVal5 = Int32.Parse(Pomona["TimeE"].InnerText);
			numVal6 = Int32.Parse(Pomona["TimeF"].InnerText);

		}

		if (gameObject.tag == "MediaCityUK") {
			numVal1 = Int32.Parse(MediaCityUK["TimeA"].InnerText);
			numVal2 = Int32.Parse(MediaCityUK["TimeB"].InnerText);
			numVal3 = Int32.Parse(MediaCityUK["TimeC"].InnerText);
			numVal4 = Int32.Parse(MediaCityUK["TimeD"].InnerText);
			numVal5 = Int32.Parse(MediaCityUK["TimeE"].InnerText);
			numVal6 = Int32.Parse(MediaCityUK["TimeF"].InnerText);

		}

		//THIS IS THE END OF READ XML eccles
	}



	//THIS IS WHERE WE READ THE XML EastDidsbury
	public void ReadXMLDataEastDidsbury(){
		XmlDocument newXml = new XmlDocument();

		try { newXml.Load(filePathEastDidsbury); }
		catch { Debug.Log("Failed to load file"); }

		XmlNodeList stopList = newXml.DocumentElement.ChildNodes;


		// these are the stops
		XmlNode EastDidsbury = stopList[0];

		XmlNode DidsburyVillage = stopList[1];

		XmlNode WestDidsbury = stopList[2];

		XmlNode BurtonRoad = stopList[3];

		XmlNode Withington = stopList[4];

		XmlNode StWerburghsRoad = stopList[5];

		XmlNode Chorlton = stopList[6];

		XmlNode Firswood = stopList[7];




		//THIS IS THE SWITCHER

		if (gameObject.tag == "EastDidsbury") {
			numVal1 = Int32.Parse(EastDidsbury["TimeA"].InnerText);
			numVal2 = Int32.Parse(EastDidsbury["TimeB"].InnerText);
			numVal3 = Int32.Parse(EastDidsbury["TimeC"].InnerText);
			numVal4 = Int32.Parse(EastDidsbury["TimeD"].InnerText);
			numVal5 = Int32.Parse(EastDidsbury["TimeE"].InnerText);
			numVal6 = Int32.Parse(EastDidsbury["TimeF"].InnerText);

		}

		if (gameObject.tag == "DidsburyVillage") {
			numVal1 = Int32.Parse(DidsburyVillage["TimeA"].InnerText);
			numVal2 = Int32.Parse(DidsburyVillage["TimeB"].InnerText);
			numVal3 = Int32.Parse(DidsburyVillage["TimeC"].InnerText);
			numVal4 = Int32.Parse(DidsburyVillage["TimeD"].InnerText);
			numVal5 = Int32.Parse(DidsburyVillage["TimeE"].InnerText);
			numVal6 = Int32.Parse(DidsburyVillage["TimeF"].InnerText);

		}

		if (gameObject.tag == "WestDidsbury") {
			numVal1 = Int32.Parse(WestDidsbury["TimeA"].InnerText);
			numVal2 = Int32.Parse(WestDidsbury["TimeB"].InnerText);
			numVal3 = Int32.Parse(WestDidsbury["TimeC"].InnerText);
			numVal4 = Int32.Parse(WestDidsbury["TimeD"].InnerText);
			numVal5 = Int32.Parse(WestDidsbury["TimeE"].InnerText);
			numVal6 = Int32.Parse(WestDidsbury["TimeF"].InnerText);

		}

		if (gameObject.tag == "BurtonRoad") {
			numVal1 = Int32.Parse(BurtonRoad["TimeA"].InnerText);
			numVal2 = Int32.Parse(BurtonRoad["TimeB"].InnerText);
			numVal3 = Int32.Parse(BurtonRoad["TimeC"].InnerText);
			numVal4 = Int32.Parse(BurtonRoad["TimeD"].InnerText);
			numVal5 = Int32.Parse(BurtonRoad["TimeE"].InnerText);
			numVal6 = Int32.Parse(BurtonRoad["TimeF"].InnerText);

		}

		if (gameObject.tag == "Withington") {
			numVal1 = Int32.Parse(Withington["TimeA"].InnerText);
			numVal2 = Int32.Parse(Withington["TimeB"].InnerText);
			numVal3 = Int32.Parse(Withington["TimeC"].InnerText);
			numVal4 = Int32.Parse(Withington["TimeD"].InnerText);
			numVal5 = Int32.Parse(Withington["TimeE"].InnerText);
			numVal6 = Int32.Parse(Withington["TimeF"].InnerText);

		}

		if (gameObject.tag == "StWerburghsRoad") {
			numVal1 = Int32.Parse(StWerburghsRoad["TimeA"].InnerText);
			numVal2 = Int32.Parse(StWerburghsRoad["TimeB"].InnerText);
			numVal3 = Int32.Parse(StWerburghsRoad["TimeC"].InnerText);
			numVal4 = Int32.Parse(StWerburghsRoad["TimeD"].InnerText);
			numVal5 = Int32.Parse(StWerburghsRoad["TimeE"].InnerText);
			numVal6 = Int32.Parse(StWerburghsRoad["TimeF"].InnerText);

		}

		if (gameObject.tag == "Chorlton") {
			numVal1 = Int32.Parse(Chorlton["TimeA"].InnerText);
			numVal2 = Int32.Parse(Chorlton["TimeB"].InnerText);
			numVal3 = Int32.Parse(Chorlton["TimeC"].InnerText);
			numVal4 = Int32.Parse(Chorlton["TimeD"].InnerText);
			numVal5 = Int32.Parse(Chorlton["TimeE"].InnerText);
			numVal6 = Int32.Parse(Chorlton["TimeF"].InnerText);

		}

		if (gameObject.tag == "Firswood") {
			numVal1 = Int32.Parse(Firswood["TimeA"].InnerText);
			numVal2 = Int32.Parse(Firswood["TimeB"].InnerText);
			numVal3 = Int32.Parse(Firswood["TimeC"].InnerText);
			numVal4 = Int32.Parse(Firswood["TimeD"].InnerText);
			numVal5 = Int32.Parse(Firswood["TimeE"].InnerText);
			numVal6 = Int32.Parse(Firswood["TimeF"].InnerText);

		}


		//THIS IS THE END OF READ XML EastDidsbury
	}











	//THIS IS WHERE WE READ THE XML Rochdale
	public void ReadXMLDataRochdale(){
		XmlDocument newXml = new XmlDocument();

		try { newXml.Load(filePathRochdale); }
		catch { Debug.Log("Failed to load file"); }

		XmlNodeList stopList = newXml.DocumentElement.ChildNodes;


		// these are the stops
		XmlNode Monsall = stopList[0];

		XmlNode CentralPark = stopList[1];

		XmlNode Weaste = stopList[2];

		XmlNode Failsworth = stopList[3];

		XmlNode Hollinwood = stopList[4];

		XmlNode SouthChadderton = stopList[5];

		XmlNode Freehold = stopList[6];

		XmlNode Westwood = stopList[7];

		XmlNode OldhamKingStreet = stopList[8];

		XmlNode OldhamCentral = stopList[9];

		XmlNode OldhamMumps = stopList[10];

		XmlNode Derker = stopList[11];

		XmlNode ShawCrompton = stopList[12];

		XmlNode Newhey = stopList[13];

		XmlNode Milnrow = stopList[14];

		XmlNode KingswayBusinessPark = stopList[15];

		XmlNode Newbold = stopList[16];

		XmlNode Rochdale = stopList[17];


		//THIS IS THE SWITCHER

		if (gameObject.tag == "Monsall") {
			numVal1 = Int32.Parse(Monsall["TimeA"].InnerText);
			numVal2 = Int32.Parse(Monsall["TimeB"].InnerText);
			numVal3 = Int32.Parse(Monsall["TimeC"].InnerText);
			numVal4 = Int32.Parse(Monsall["TimeD"].InnerText);
			numVal5 = Int32.Parse(Monsall["TimeE"].InnerText);
			numVal6 = Int32.Parse(Monsall["TimeF"].InnerText);

		}

		if (gameObject.tag == "CentralPark") {
			numVal1 = Int32.Parse(CentralPark["TimeA"].InnerText);
			numVal2 = Int32.Parse(CentralPark["TimeB"].InnerText);
			numVal3 = Int32.Parse(CentralPark["TimeC"].InnerText);
			numVal4 = Int32.Parse(CentralPark["TimeD"].InnerText);
			numVal5 = Int32.Parse(CentralPark["TimeE"].InnerText);
			numVal6 = Int32.Parse(CentralPark["TimeF"].InnerText);

		}

		if (gameObject.tag == "Weaste") {
			numVal1 = Int32.Parse(Weaste["TimeA"].InnerText);
			numVal2 = Int32.Parse(Weaste["TimeB"].InnerText);
			numVal3 = Int32.Parse(Weaste["TimeC"].InnerText);
			numVal4 = Int32.Parse(Weaste["TimeD"].InnerText);
			numVal5 = Int32.Parse(Weaste["TimeE"].InnerText);
			numVal6 = Int32.Parse(Weaste["TimeF"].InnerText);

		}

		if (gameObject.tag == "Failsworth") {
			numVal1 = Int32.Parse(Failsworth["TimeA"].InnerText);
			numVal2 = Int32.Parse(Failsworth["TimeB"].InnerText);
			numVal3 = Int32.Parse(Failsworth["TimeC"].InnerText);
			numVal4 = Int32.Parse(Failsworth["TimeD"].InnerText);
			numVal5 = Int32.Parse(Failsworth["TimeE"].InnerText);
			numVal6 = Int32.Parse(Failsworth["TimeF"].InnerText);

		}

		if (gameObject.tag == "Hollinwood") {
			numVal1 = Int32.Parse(Hollinwood["TimeA"].InnerText);
			numVal2 = Int32.Parse(Hollinwood["TimeB"].InnerText);
			numVal3 = Int32.Parse(Hollinwood["TimeC"].InnerText);
			numVal4 = Int32.Parse(Hollinwood["TimeD"].InnerText);
			numVal5 = Int32.Parse(Hollinwood["TimeE"].InnerText);
			numVal6 = Int32.Parse(Hollinwood["TimeF"].InnerText);

		}

		if (gameObject.tag == "SouthChadderton") {
			numVal1 = Int32.Parse(SouthChadderton["TimeA"].InnerText);
			numVal2 = Int32.Parse(SouthChadderton["TimeB"].InnerText);
			numVal3 = Int32.Parse(SouthChadderton["TimeC"].InnerText);
			numVal4 = Int32.Parse(SouthChadderton["TimeD"].InnerText);
			numVal5 = Int32.Parse(SouthChadderton["TimeE"].InnerText);
			numVal6 = Int32.Parse(SouthChadderton["TimeF"].InnerText);

		}

		if (gameObject.tag == "Freehold") {
			numVal1 = Int32.Parse(Freehold["TimeA"].InnerText);
			numVal2 = Int32.Parse(Freehold["TimeB"].InnerText);
			numVal3 = Int32.Parse(Freehold["TimeC"].InnerText);
			numVal4 = Int32.Parse(Freehold["TimeD"].InnerText);
			numVal5 = Int32.Parse(Freehold["TimeE"].InnerText);
			numVal6 = Int32.Parse(Freehold["TimeF"].InnerText);

		}

		if (gameObject.tag == "Westwood") {
			numVal1 = Int32.Parse(Westwood["TimeA"].InnerText);
			numVal2 = Int32.Parse(Westwood["TimeB"].InnerText);
			numVal3 = Int32.Parse(Westwood["TimeC"].InnerText);
			numVal4 = Int32.Parse(Westwood["TimeD"].InnerText);
			numVal5 = Int32.Parse(Westwood["TimeE"].InnerText);
			numVal6 = Int32.Parse(Westwood["TimeF"].InnerText);

		}


		if (gameObject.tag == "OldhamKingStreet") {
			numVal1 = Int32.Parse(OldhamKingStreet["TimeA"].InnerText);
			numVal2 = Int32.Parse(OldhamKingStreet["TimeB"].InnerText);
			numVal3 = Int32.Parse(OldhamKingStreet["TimeC"].InnerText);
			numVal4 = Int32.Parse(OldhamKingStreet["TimeD"].InnerText);
			numVal5 = Int32.Parse(OldhamKingStreet["TimeE"].InnerText);
			numVal6 = Int32.Parse(OldhamKingStreet["TimeF"].InnerText);

		}

		if (gameObject.tag == "OldhamCentral") {
			numVal1 = Int32.Parse(OldhamCentral["TimeA"].InnerText);
			numVal2 = Int32.Parse(OldhamCentral["TimeB"].InnerText);
			numVal3 = Int32.Parse(OldhamCentral["TimeC"].InnerText);
			numVal4 = Int32.Parse(OldhamCentral["TimeD"].InnerText);
			numVal5 = Int32.Parse(OldhamCentral["TimeE"].InnerText);
			numVal6 = Int32.Parse(OldhamCentral["TimeF"].InnerText);
		
		}

		if (gameObject.tag == "OldhamMumps") {
			numVal1 = Int32.Parse(OldhamMumps["TimeA"].InnerText);
			numVal2 = Int32.Parse(OldhamMumps["TimeB"].InnerText);
			numVal3 = Int32.Parse(OldhamMumps["TimeC"].InnerText);
			numVal4 = Int32.Parse(OldhamMumps["TimeD"].InnerText);
			numVal5 = Int32.Parse(OldhamMumps["TimeE"].InnerText);
			numVal6 = Int32.Parse(OldhamMumps["TimeF"].InnerText);
		
		}

		if (gameObject.tag == "Derker") {
			numVal1 = Int32.Parse(Derker["TimeA"].InnerText);
			numVal2 = Int32.Parse(Derker["TimeB"].InnerText);
			numVal3 = Int32.Parse(Derker["TimeC"].InnerText);
			numVal4 = Int32.Parse(Derker["TimeD"].InnerText);
			numVal5 = Int32.Parse(Derker["TimeE"].InnerText);
			numVal6 = Int32.Parse(Derker["TimeF"].InnerText);
		
		}

		if (gameObject.tag == "ShawCrompton") {
			numVal1 = Int32.Parse(ShawCrompton["TimeA"].InnerText);
			numVal2 = Int32.Parse(ShawCrompton["TimeB"].InnerText);
			numVal3 = Int32.Parse(ShawCrompton["TimeC"].InnerText);
			numVal4 = Int32.Parse(ShawCrompton["TimeD"].InnerText);
			numVal5 = Int32.Parse(ShawCrompton["TimeE"].InnerText);
			numVal6 = Int32.Parse(ShawCrompton["TimeF"].InnerText);
		
		}

		if (gameObject.tag == "Newhey") {
			numVal1 = Int32.Parse(Newhey["TimeA"].InnerText);
			numVal2 = Int32.Parse(Newhey["TimeB"].InnerText);
			numVal3 = Int32.Parse(Newhey["TimeC"].InnerText);
			numVal4 = Int32.Parse(Newhey["TimeD"].InnerText);
			numVal5 = Int32.Parse(Newhey["TimeE"].InnerText);
			numVal6 = Int32.Parse(Newhey["TimeF"].InnerText);

		}

		if (gameObject.tag == "Milnrow") {
			numVal1 = Int32.Parse(Milnrow["TimeA"].InnerText);
			numVal2 = Int32.Parse(Milnrow["TimeB"].InnerText);
			numVal3 = Int32.Parse(Milnrow["TimeC"].InnerText);
			numVal4 = Int32.Parse(Milnrow["TimeD"].InnerText);
			numVal5 = Int32.Parse(Milnrow["TimeE"].InnerText);
			numVal6 = Int32.Parse(Milnrow["TimeF"].InnerText);

		}

		if (gameObject.tag == "KingswayBusinessPark") {
			numVal1 = Int32.Parse(KingswayBusinessPark["TimeA"].InnerText);
			numVal2 = Int32.Parse(KingswayBusinessPark["TimeB"].InnerText);
			numVal3 = Int32.Parse(KingswayBusinessPark["TimeC"].InnerText);
			numVal4 = Int32.Parse(KingswayBusinessPark["TimeD"].InnerText);
			numVal5 = Int32.Parse(KingswayBusinessPark["TimeE"].InnerText);
			numVal6 = Int32.Parse(KingswayBusinessPark["TimeF"].InnerText);

		}


		if (gameObject.tag == "Newbold") {
			numVal1 = Int32.Parse(Newbold["TimeA"].InnerText);
			numVal2 = Int32.Parse(Newbold["TimeB"].InnerText);
			numVal3 = Int32.Parse(Newbold["TimeC"].InnerText);
			numVal4 = Int32.Parse(Newbold["TimeD"].InnerText);
			numVal5 = Int32.Parse(Newbold["TimeE"].InnerText);
			numVal6 = Int32.Parse(Newbold["TimeF"].InnerText);

		}

		if (gameObject.tag == "Rochdale") {
			numVal1 = Int32.Parse(Rochdale["TimeA"].InnerText);
			numVal2 = Int32.Parse(Rochdale["TimeB"].InnerText);
			numVal3 = Int32.Parse(Rochdale["TimeC"].InnerText);
			numVal4 = Int32.Parse(Rochdale["TimeD"].InnerText);
			numVal5 = Int32.Parse(Rochdale["TimeE"].InnerText);
			numVal6 = Int32.Parse(Rochdale["TimeF"].InnerText);

		}



		//THIS IS THE END OF READ XML Monsall
	}

























	 

	//THESE ARE THE NUMBERS FOR THE BARS
	void TaskOnClick1(){
		 
		transform.localScale = new Vector3(100, 100, numVal1);
	}

	void TaskOnClick2(){
		 
		transform.localScale = new Vector3(100, 100, numVal2);
	}

	void TaskOnClick3(){
		 
		transform.localScale = new Vector3(100, 100, numVal3);
	}

	void TaskOnClick4(){
		 
		transform.localScale = new Vector3(100, 100, numVal4);
	}


	void TaskOnClick5(){
		 
		transform.localScale = new Vector3(100, 100, numVal5);
	}

	void TaskOnClick6(){
		 
		transform.localScale = new Vector3(100, 100, numVal6);
	}























	void Update (){
		//transform.localScale += new Vector3(0, timeSlider.value, 0);
}
}

