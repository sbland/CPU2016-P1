using UnityEngine;
using System.Collections;
using System.IO;
using System.Xml;
using System.Collections.Generic;

public class XmlScheduleData
{
    //public static List<Route> routes = new List<Route>();
    public static Dictionary<string, Route> routes = new Dictionary<string, Route>();
    public static Dictionary<string, TramStop> tramStops = new Dictionary<string, TramStop>();

    public static bool loadingData = true;
    
}



public class Route
{
    public string routeName;
    public string serviceID;
    //public List<TramStop> stopsOnRoute = new List<TramStop>();
    public Dictionary<string, TramStop> stopsOnRoute = new Dictionary<string, TramStop>();
    public Dictionary<string, Trip> trips = new Dictionary<string, Trip>();
}

public class Trip
{
    public string tripId;
    public string parentServiceID;
    public int tripCountNo;
    public List<ScheduledStop> scheduledStopTimes = new List<ScheduledStop>();

}

public class ScheduledStop
{
    public int stopTimeId;
    public TramStop stopObject;
    public string stopName;
    public string stopId;
    public float stopTime;
    public int stopCountNo;

}

public class XmlScheduleLoader : MonoBehaviour {

    //XML Files
    public TextAsset tramStopsXml;
    public TextAsset tramRoutesXml;
    public TextAsset routeScheduleXml;

    // Use this for initialization
    void Start () {
        //Pause Time while loading

        XmlScheduleData.loadingData = true;
        loadTramStops();
        loadTramRoutes();
        loadScheduleData();

    }

    // Update is called once per frame
    void Update () {
        if (XmlScheduleData.loadingData)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
	}

    
    void loadTramStops()
    {        

        XmlDocument tramRoutesXmlData = new XmlDocument(); //new xml var to store xml doc 

        try { tramRoutesXmlData.LoadXml(tramStopsXml.text); }
        catch { Debug.Log("Failed to load xml file"); } //load the xml doc into the xml var

        XmlNodeList tramStopList = tramRoutesXmlData.DocumentElement.ChildNodes;

        foreach (XmlNode stopPointer in tramStopList)
        {
            int coordX = int.Parse(stopPointer["X"].InnerText);
            int coordY = int.Parse(stopPointer["Y"].InnerText);
            string stopName = stopPointer.Attributes["name"].Value;
            string stopId = stopPointer.Attributes["id"].Value;
            
            TramStop tramStop = new TramStop(stopName, stopId, coordX, coordY);
           
            tramStop.Initiate();
        }


       


    }

    void loadTramRoutes()
    {
        //Route Stop List Loader
        XmlDocument routeStopListXmlData = new XmlDocument(); //new xml var to store xml doc 
        try { routeStopListXmlData.LoadXml(tramRoutesXml.text); }
        catch { Debug.Log("Failed to load xml file"); } //load the xml doc into the xml var

        XmlNodeList routeList = routeStopListXmlData.DocumentElement.ChildNodes;

        foreach (XmlNode routePointer in routeList)
        {
            Route route = new Route();
            route.routeName = routePointer.Attributes["routeName"].Value;
            route.serviceID = routePointer.Attributes["serviceID"].Value;

            XmlNodeList stopList = routePointer.ChildNodes;
            foreach (XmlNode stopPointer in stopList)
            {
                //Load stop names into each route as dictionarys
                               
                try {
                    TramStop tramStopTemp = XmlScheduleData.tramStops[stopPointer.InnerText];
                    route.stopsOnRoute.Add(stopPointer.Name, XmlScheduleData.tramStops[stopPointer.InnerText]);
                }
                catch
                {
                    Debug.Log("Stop: " + stopPointer.InnerText + " does not exist");
                }
                
                
            }
            XmlScheduleData.routes.Add(route.serviceID, route);
        }
    }

    void loadScheduleData()
    {


        XmlDocument scheduleXml = new XmlDocument();
        try { scheduleXml.LoadXml(routeScheduleXml.text); }
        catch { Debug.Log("Failed to load xml file"); } //load the xml doc into the xml var

        

        XmlNodeList routeList = scheduleXml.DocumentElement.ChildNodes;
        foreach (XmlNode routePointer in routeList)
        {
            Route route = XmlScheduleData.routes[routePointer.Attributes["serviceID"].Value];

            int tripCounter = 0;
            XmlNodeList tripList = routePointer.ChildNodes;
            foreach (XmlNode tripPointer in tripList)
            {
                Trip trip = new Trip();
                trip.tripId = tripPointer.Attributes["id"].Value;
                trip.tripCountNo = tripCounter;
                trip.parentServiceID = route.serviceID;

                int stopCounter = 0;
                XmlNodeList stopList = tripPointer.ChildNodes;
                foreach (XmlNode stopPointer in stopList)
                {
                    ScheduledStop scheduledStop = new ScheduledStop();


                    //set stop values
                    scheduledStop.stopObject = route.stopsOnRoute[stopPointer.Name];
                    scheduledStop.stopTime = float.Parse(stopPointer.InnerText);
                    scheduledStop.stopCountNo = stopCounter;


                    //add to stop list
                    trip.scheduledStopTimes.Add(scheduledStop);
                    stopCounter += 1;
                }


                //add to trip list
                route.trips.Add(trip.tripId, trip);

                //Start timer to commence trip
                float tripStartTime = float.Parse(tripPointer.ChildNodes[0].InnerText);
                StartCoroutine(DeferedTripStarter(tripStartTime - TimeInfo.currentTime, trip.tripId, route.serviceID));

                tripCounter += 1;
            }



        }

        XmlScheduleData.loadingData = false;
        Debug.Log("Loading Complete");
        //Time.timeScale = 1;
    }

    public IEnumerator DeferedTripStarter(float startTime, string tripId, string routeId)
    {
        yield return new WaitForSeconds(startTime * TimeInfo.secondsEqualToHour);
        Debug.Log("Start new trip " + tripId + " on route " + routeId);
        int tramsLeft = TramData.tramListAvailable.Count;
        if(tramsLeft >0)
        {
            TramClass tram = TramData.tramListAvailable[tramsLeft - 1];
            TramData.tramListAvailable.RemoveAt(tramsLeft - 1);
            Debug.Log("Trams left " + (tramsLeft-1));
            tram.currentTrip = XmlScheduleData.routes[routeId].trips[tripId];
            tram.currentRoute = XmlScheduleData.routes[routeId];
            tram.startTrip();
        }
        else //no trams left
        {
            Debug.Log("No trams left");
        }

        yield break;
    }
}
