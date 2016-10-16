using UnityEngine;
using System;
using System.Collections;
using System.IO;




public class ReadData : MonoBehaviour {

    public string dataLocation;
    static string dataFileUrl;
    string jsonTestString;



    [Serializable]
    public class City
    {
        public string[] Location;
        public int[] Year2005;
    }

    [Serializable]
    public class FuelTYPE 
    {
        public string[] petrol;
        //public City petrol;
    }


    /*
     [Serializable]
     public class dataFromJSON
     {

         public string location;
         public string year;
         public int fuelUse;

         public static dataFromJSON CreateFromJSON(string jsonString)
         {
             return JsonUtility.FromJson<dataFromJSON>(jsonString);
         }
     }
     */

    // Use this for initialization
    void Start () {

        dataFileUrl = dataLocation + "JsonTest.json";
        jsonTestString = File.ReadAllText(@dataFileUrl);
        Debug.Log("jsonout = " + jsonTestString);

        //City testCity = new City();
        //testCity = JsonUtility.FromJson<City>(jsonTestString);
        //Debug.Log(testCity.Location[1]);

        FuelTYPE testFuel = new FuelTYPE();
        testFuel = JsonUtility.FromJson<FuelTYPE>(jsonTestString);
        Debug.Log("testfuel = " + testFuel.petrol[0]);
        //City testCityB = new City();
        
     



        //testCityB = JsonUtility.FromJson<City>(testFuel.petrol[0]);

        // testCityB = testFuel.Petrol[1];
        // Debug.Log(testCityB);
    }

    // Update is called once per frame
    void Update () {
	
	}
}
