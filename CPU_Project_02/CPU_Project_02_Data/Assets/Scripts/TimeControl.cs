﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public static class TimeInfo
{
    public static int hour;
    public static int secondsEqualToHour;
    public static bool runTimer = true;
}

public class TimeControl : MonoBehaviour {

    public bool runTimer = true;
    public int secondsEqualToHour = 2;

    public Text timeText;
    public float currentTime = 0;
        
        // Use this for initialization
	void Start () {
        TimeInfo.hour = 0;
        TimeInfo.secondsEqualToHour = secondsEqualToHour;
        TimeInfo.runTimer = runTimer;
        StartCoroutine(UpdateTime());
    }
	
	// Update is called once per frame
	void Update () {
        currentTime += Time.deltaTime;
        timeText.text = "Cur Time = " + currentTime;


    }

    private IEnumerator UpdateTime ()

    {
        while (runTimer)
        {
            TimeInfo.hour += 1;
            Debug.Log("hour = " + TimeInfo.hour);
            

            yield return new WaitForSeconds(secondsEqualToHour);
        }
        yield return new WaitForSeconds(secondsEqualToHour);
        

        yield break;
    }
}