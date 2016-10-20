﻿using UnityEngine;
using System.Collections;
using System.IO;
using System.Xml;
using System.Collections.Generic;

public class XmlScheduleData
{
    //public static List<Route> routes = new List<Route>();
    public static Dictionary<string, Route> routes = new Dictionary<string, Route>();
    public static bool loadingData = true;
}

public class Route
{
    public string routeName;
    public string serviceID;
    public List<Trip> trips = new List<Trip>();
}

public class Trip
{
    public string tripId;
    public int tripCountNo;
    public List<ScheduledStop> scheduledStops = new List<ScheduledStop>();
}

public class ScheduledStop
{
    public int stopTimeId;
    public string stopName;
    public float stopTime;
    public int stopCountNo;

}

public class XmlScheduleLoader : MonoBehaviour {

    public TextAsset routeScheduleXml;

    // Use this for initialization
    void Start () {
        loadScheduleData();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void loadScheduleData()
    {
        XmlDocument scheduleXml = new XmlDocument();
        try { scheduleXml.LoadXml(routeScheduleXml.text); }
        catch { Debug.Log("Failed to load xml file"); } //load the xml doc into the xml var

        

        XmlNodeList routeList = scheduleXml.DocumentElement.ChildNodes;
        foreach (XmlNode routePointer in routeList)
        {
            //Debug.Log(routePointer.Attributes["routeName"].Value);
            Route route = new Route();
            route.routeName = routePointer.Attributes["routeName"].Value;
            route.serviceID = routePointer.Attributes["serviceID"].Value;


            int tripCounter = 0;
            XmlNodeList tripList = routePointer.ChildNodes;
            foreach (XmlNode tripPointer in tripList)
            {
                Trip trip = new Trip();
                trip.tripId = tripPointer.Attributes["id"].Value;
                trip.tripCountNo = tripCounter;

                int stopCounter = 0;
                XmlNodeList stopList = tripPointer.ChildNodes;
                foreach (XmlNode stopPointer in stopList)
                {
                    ScheduledStop scheduledStop = new ScheduledStop();
                    //set stop values
                    //scheduledStop.stopName = stopPointer.Attributes["name"].Value;
                    //scheduledStop.stopTimeId = int.Parse(stopPointer.Attributes["count"].Value);
                    scheduledStop.stopTime = float.Parse(stopPointer.InnerText);
                    scheduledStop.stopCountNo = stopCounter;


                    //add to stop list
                    trip.scheduledStops.Add(scheduledStop);
                    stopCounter += 1;
                }


                //add to trip list
                route.trips.Add(trip);
                tripCounter += 1;
            }

            XmlScheduleData.routes.Add(route.serviceID, route);
            
        }
        //Debug.Log(XmlScheduleData.routes["BuryOut"].trips[1].scheduledStops[3].stopName);
        XmlScheduleData.loadingData = false;
    }
}
