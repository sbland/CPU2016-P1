using UnityEngine;
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
    public string name;
    public List<Trip> trips = new List<Trip>();
}

public class Trip
{
    public int tripId;
    public List<ScheduledStop> scheduledStops = new List<ScheduledStop>();
}

public class ScheduledStop
{
    public int stopTimeId;
    public string stopName;
    public int stopTime;

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
            Route route = new Route();
            route.name = routePointer.Attributes["name"].Value;



            XmlNodeList tripList = routePointer.ChildNodes;
            foreach (XmlNode tripPointer in tripList)
            {
                Trip trip = new Trip();
                trip.tripId = int.Parse(tripPointer.Attributes["count"].Value);

                XmlNodeList stopList = tripPointer.ChildNodes;
                foreach (XmlNode stopPointer in stopList)
                {
                    ScheduledStop scheduledStop = new ScheduledStop();
                    scheduledStop.stopName = stopPointer.Attributes["name"].Value;
                    scheduledStop.stopTimeId = int.Parse(stopPointer.Attributes["count"].Value);
                    scheduledStop.stopTime = int.Parse(stopPointer.InnerText);
                    trip.scheduledStops.Add(scheduledStop);

                }

                route.trips.Add(trip);

            }

            XmlScheduleData.routes.Add(route.name, route);
            
        }
        //Debug.Log(XmlScheduleData.routes["BuryOut"].trips[1].scheduledStops[3].stopName);
        XmlScheduleData.loadingData = false;
    }
}
