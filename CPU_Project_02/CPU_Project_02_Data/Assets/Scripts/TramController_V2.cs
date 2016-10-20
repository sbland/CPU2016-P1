using UnityEngine;
using System.Collections;
using System.IO;
using System.Xml;

public class TramController_V2 : MonoBehaviour
{

    public bool debugMe = false;
    public string serviceID = "Serv000001";

    //Move variables
    public GameObject[] tramStops;
    public int startStopId = 0;
    private int previousStopId = 0;
    private int targetStopId = 0;
    private int totalNoStops;
    //public bool Outbound = true;
    private float percentageAlongPath = 1;
    public float timeToReachNextStation;
    private int currentTrip = 0;

    // Use this for initialization
    void Start()
    {
        transform.position = tramStops[startStopId].transform.position;
        totalNoStops = tramStops.Length;
        previousStopId = startStopId;
        targetStopId = previousStopId;

    }

    // Update is called once per frame
    void Update()
    {
        if (!XmlScheduleData.loadingData)
        {
            if (TimeInfo.currentTime >= XmlScheduleData.routes[serviceID].trips[0].scheduledStops[0].stopTime)
            {
                if (percentageAlongPath >= 1)
                {
                    ReachedStation();

                }
                else
                {
                    MoveToNextStation();
                }
            }
            //else
            //{
            //    if(debugMe)
            //    {
            //        Debug.Log(XmlScheduleData.routes[serviceID].trips[currentTrip].scheduledStops[0].stopTime);
            //    }

            //}

        }

    }

    public void MoveToNextStation()
    {

        percentageAlongPath += (Time.deltaTime / timeToReachNextStation);

        transform.position = Vector3.Lerp(tramStops[previousStopId].transform.position, tramStops[targetStopId].transform.position, percentageAlongPath);

    }

    void ReachedStation()
    {
        previousStopId = targetStopId;
        ChangeTargetStation();

        float nextStopTime = XmlScheduleData.routes[serviceID].trips[currentTrip].scheduledStops[targetStopId].stopTime;
        timeToReachNextStation = nextStopTime - TimeInfo.currentTime;
        percentageAlongPath = 0;

    }

    public void ChangeTargetStation()
    {

        if (targetStopId == XmlScheduleData.routes[serviceID].trips[currentTrip].scheduledStops.Count - 1) //end of line
        {
            //targetStopId = 1;
            //previousStopId = 0;
            //currentTrip += 1;
            //transform.position = tramStops[previousStopId].transform.position;
            Destroy(this);
        }
        else
        {
            targetStopId += 1;
        }
    }


}
