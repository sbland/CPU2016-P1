using UnityEngine;
using System.Collections;



public class TramClass : MonoBehaviour{

    //GameObject tramObject;
    public Trip currentTrip;
    public Route currentRoute;
    
    public int startStopId = 0;
    public int previousStopId = 0;
    public int targetStopId = 0;
    //public int totalNoStops;

    private TramStop firstStop;
    private TramStop previousStop;
    private TramStop targetStop;

    private float percentageAlongPath = 1;
    public float timeToReachNextStation;


    public void initiate()
    {
        //tramObject = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        //gameObject.transform.position = new Vector3(0, TramData.tramListAvailable.Count, 0);
        //gameObject.name = "Tram_" + TramData.tramListAvailable.Count;
    }

    public void StartTrip()
    {
        currentTrip.tripActive = true;

        firstStop = currentTrip.scheduledStopTimes[0].stopObject;
        previousStop = firstStop;
        targetStop = previousStop;


        gameObject.transform.position = new Vector3(firstStop.coordX, 0, firstStop.coordY);

        StartCoroutine(MoveTram());
    }

    public IEnumerator MoveTram ()
    {
        while(currentTrip.tripActive)
        {
            if(percentageAlongPath < 1)
            {
                MoveToNextStation();
            }
            else
            {
                Debug.Log("Reached station " + targetStop.tramStopName);
                ReachedStation();

            }
            yield return new WaitForFixedUpdate();
        }

        Debug.Log("End of trip " + currentTrip.tripId);
        yield break;

    }

    public void MoveToNextStation()
    {

        percentageAlongPath += (Time.deltaTime / timeToReachNextStation);

        transform.position = Vector3.Lerp(previousStop.tramStopGeometry.transform.position, targetStop.tramStopGeometry.transform.position, percentageAlongPath);

    }

    void ReachedStation()
    {
        previousStopId = targetStopId;
        previousStop = targetStop;
        ChangeTargetStation();

        try
        {
            float nextStopTime = currentTrip.scheduledStopTimes[targetStopId].stopTime;
            timeToReachNextStation = nextStopTime - TimeInfo.currentTime;
        }catch
        {
            Debug.Log("Failed to load stop " + targetStopId);
        }

        percentageAlongPath = 0;
    }

    public void ChangeTargetStation()
    {

        if (targetStopId == currentTrip.tripCountNo) //end of line
        {
            currentTrip.tripActive = false;
            TramData.tramListAvailable.Add(gameObject);
        }
        else
        {
            targetStopId += 1;
            targetStop = currentTrip.scheduledStopTimes[targetStopId].stopObject;

        }
    }


}
