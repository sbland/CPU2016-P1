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
    public static bool loadingTramStops = true;
    public static bool loadingTramRoutes = true;
    public static bool loadingScheduleData = true;


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
    public bool tripActive = false;

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
        Time.timeScale = 0;


        XmlScheduleData.loadingData = true;

        //Load xml data

        StartCoroutine(loadTramStops());
        StartCoroutine(loadTramRoutes());
        StartCoroutine(loadScheduleData());


    }

    // Update is called once per frame
    void Update () {

        //Pause Time while loading
        if (XmlScheduleData.loadingScheduleData || XmlScheduleData.loadingTramRoutes || XmlScheduleData.loadingTramStops)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
	}


    private IEnumerator loadTramStops()
    {   //loadScheduleData individual tram stops from xml into dictionary
        Debug.Log("Loading Tram Stops");

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
        
        XmlScheduleData.loadingTramStops = false;
        Debug.Log("Finished Loading Tram Stops");
        yield break;

    }////loadTramStops

    private IEnumerator loadTramRoutes()
    {//Route Stop List Loader


        while(XmlScheduleData.loadingTramStops)
        {
            yield return new WaitForFixedUpdate();
        }

        Debug.Log("Loading Tram Routes");

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
        Debug.Log("Finished Loading Tram Routes");
        XmlScheduleData.loadingTramRoutes = false;
        yield break;
    }////loadTramRoutes

    private IEnumerator loadScheduleData()
    {

        while (XmlScheduleData.loadingTramRoutes)
        {
            yield return new WaitForFixedUpdate();
        }

        Debug.Log("Loading Tram Schedule");

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
                    try
                    {
                        scheduledStop.stopObject = route.stopsOnRoute[stopPointer.Name];
                    }
                    catch
                    {
                        Debug.Log("Could not find " + stopPointer.Name + " in " + route.routeName);
                    }
                    
                    scheduledStop.stopTime = float.Parse(stopPointer.InnerText);
                    scheduledStop.stopCountNo = stopCounter;


                    //add to stop list
                    trip.scheduledStopTimes.Add(scheduledStop);
                    stopCounter += 1;
                }

                trip.tripCountNo = stopCounter;
                //add to trip list
                route.trips.Add(trip.tripId, trip);

                //Start timer to commence trip
                float tripStartTime = float.Parse(tripPointer.ChildNodes[0].InnerText);
                StartCoroutine(DeferedTripStarter(tripStartTime - TimeInfo.currentTime, trip.tripId, route.serviceID));

                tripCounter += 1;
            }



        }

        XmlScheduleData.loadingData = false;
        //Debug.Log("Loading Complete");
        //Time.timeScale = 1;

        Debug.Log("Finished Loading Tram Schedule");
        XmlScheduleData.loadingScheduleData = false;
        yield break;
    }

    public IEnumerator DeferedTripStarter(float startTime, string tripId, string routeId)
    {//Sets a time delay for each trip to begin based on the trip start time
        yield return new WaitForSeconds(startTime * TimeInfo.secondsEqualToHour);
        Debug.Log("Start new trip " + tripId + " on route " + routeId);
        int tramsLeft = TramData.tramListAvailable.Count;
        if(tramsLeft >0)
        {

            GameObject tram = TramData.tramListAvailable[tramsLeft - 1];
            TramData.tramListAvailable.RemoveAt(tramsLeft - 1);
            Debug.Log("Trams left " + (tramsLeft - 1));

            TramClass tramComponent = tram.GetComponent<TramClass>();
            tramComponent.currentTrip = XmlScheduleData.routes[routeId].trips[tripId];
            tramComponent.currentRoute = XmlScheduleData.routes[routeId];
            tramComponent.StartTrip();




            //TramClass tram = TramData.tramListAvailable[tramsLeft - 1];
            //TramData.tramListAvailable.RemoveAt(tramsLeft - 1);
            //Debug.Log("Trams left " + (tramsLeft-1));
            //tram.currentTrip = XmlScheduleData.routes[routeId].trips[tripId];
            //tram.currentRoute = XmlScheduleData.routes[routeId];
            //tram.StartTrip();
        }
        else //no trams left
        {
            Debug.Log("No trams left");
        }

        yield break;
    }
}
