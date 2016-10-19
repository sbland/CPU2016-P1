using UnityEngine;
using System;
using System.Collections;
using UnityEngine.UI;

public class MoveTramBetweenStations : MonoBehaviour {

    //Move variables
    public GameObject[] tramStops;
    public int startStopId = 0;
    private int previousStopId = 0;
    private int targetStopId = 1;
    private int totalNoStops;
    public bool Outbound = true;
    public float moveSpeed = 1;
    float percentageAlongPath = 1;
    public int tramsPerHour = 3;
    

    //people variables
    public int peopleOnBoard = 50;
    private TramStopObject currentStopInfo;
    public Text textOut;
    
   // public TramStopObject script;

    // Use this for initialization
    void Start () {
        transform.position = tramStops[startStopId].transform.position;
        totalNoStops = tramStops.Length;
        previousStopId = startStopId;
        targetStopId = previousStopId;

    }
	
	// Update is called once per frame
	void Update () {

        //check if reached station
        if(percentageAlongPath >=1)
        {
            ReachedStation();
           
        }
        else
        {
            MoveToNextStation();
        }
        

    }

    public void MoveToNextStation ()
    {
        //speed kept constant
        //float distanceToTravel = Vector3.Distance(tramStops[previousStopId].transform.position, tramStops[targetStopId].transform.position);
        //percentageAlongPath += ((Time.deltaTime / distanceToTravel) * moveSpeed);

        //Speed matches trams per hour

        percentageAlongPath += ((Time.deltaTime / TimeInfo.secondsEqualToHour) * tramsPerHour) ;

        transform.position = Vector3.Lerp(tramStops[previousStopId].transform.position, tramStops[targetStopId].transform.position, percentageAlongPath);

    }


    public void ReachedStation ()
    {
        //Reset Target
        percentageAlongPath = 0;
        previousStopId = targetStopId;
        currentStopInfo = tramStops[previousStopId].GetComponent<TramStopObject>();
        ExchangePassengers();

    }

    public void ExchangePassengers ()
    {
        int numberOfPeopleGettingOn;
        int numberOfPeopleGettingOff;

        int tempint = currentStopInfo.peopleBoardingPerHour / tramsPerHour;
        //Debug.Log(tramStops[previousStopId].name + " - Capacity " + tempint + " People at station" + currentStopInfo.peopleAtStation);


        //Decide how many people are getting on
        if ((currentStopInfo.peopleBoardingPerHour / tramsPerHour) <= currentStopInfo.peopleAtStation)
        {
            numberOfPeopleGettingOn = currentStopInfo.peopleBoardingPerHour / tramsPerHour;
            //Debug.Log("Enough peeps");
        }
        else
        {
            //Debug.Log("Not enough peeps");
            numberOfPeopleGettingOn = currentStopInfo.peopleAtStation;
            
        }
        //Debug.Log("People getting on " + numberOfPeopleGettingOn);

        ////Decide how many people getting off
        if(currentStopInfo.peopleAlightingPerHour / tramsPerHour <= peopleOnBoard)
        {
            numberOfPeopleGettingOff = currentStopInfo.peopleAlightingPerHour / tramsPerHour;
        }
        else
        {
            numberOfPeopleGettingOff = peopleOnBoard;
        }
        

        peopleOnBoard += numberOfPeopleGettingOn;
        peopleOnBoard -= numberOfPeopleGettingOff;

        currentStopInfo.peopleAtStation -= numberOfPeopleGettingOn; //People left at the station;

        textOut.text = "People on Board = " + peopleOnBoard;

        ////float scaleMe = peopleOnBoard / 10;
        ////transform.localScale =  new Vector3(scaleMe,scaleMe,scaleMe);

        ChangeTargetStation();
    }

    public void ChangeTargetStation()
    {
        if (targetStopId == totalNoStops - 1) //end of line
        {
            Outbound = false;
            targetStopId -= 1;
        }
        else if (targetStopId == 0) //back at the start
        {
            //Debug.Log("You are back home!");
            Outbound = true;
            targetStopId += 1;
        }
        else if (Outbound) //moving to end
        {
            targetStopId += 1;
        }
        else if (!Outbound)//moving to start
        {
            targetStopId -= 1;
        }
    }
}
