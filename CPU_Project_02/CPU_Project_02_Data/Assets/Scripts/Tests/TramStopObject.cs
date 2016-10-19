using UnityEngine;
using System.Collections;

public class TramStopObject : MonoBehaviour
{

    public int peopleBoardingPerHour = 100;
    public int peopleAlightingPerHour = 50;
    public float peopleAtStationF = 10;
    public int peopleAtStation = 10;

    // Use this for initialization
    void Start()
    {
        //StartCoroutine(updatePeopleCounts());
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector3(1, peopleAtStation / 10, 1);
        peopleAtStationF += (Time.deltaTime / TimeInfo.secondsEqualToHour) * peopleBoardingPerHour;
        peopleAtStation = (int)Mathf.Round(peopleAtStationF);
    }


    private IEnumerator updatePeopleCounts()
    {
        while (TimeInfo.runTimer)
        {
            peopleAtStation += peopleBoardingPerHour;
            yield return new WaitForSeconds(TimeInfo.secondsEqualToHour);

        }


        yield break;
    }
}
