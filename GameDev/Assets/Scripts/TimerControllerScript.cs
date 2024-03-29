using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class TimerControllerScript : MonoBehaviour
{

    public static TimerControllerScript instance;

    public Text timeCounter;

    private TimeSpan timePlaying;
    private bool timerGoing;

    private float elapsedTime;
    public double timeInSeconds; 

    private void Awake() {
        instance = this; 
    }

    private void Start()
    {
        timeCounter.text = "Time: 00:00.00";
        timerGoing = false;
        BeginTimer();
        
    }

    private void BeginTimer() {
        timerGoing = true;

        elapsedTime = 0f;
        StartCoroutine(UpdateTimer());
    }

    public void EndTimer() {
        timerGoing = false; 
    }

    private IEnumerator UpdateTimer() {
        while (timerGoing) {
            elapsedTime += Time.deltaTime;
            timePlaying = TimeSpan.FromSeconds(elapsedTime);
            timeInSeconds = timePlaying.TotalSeconds; 
            string timePlayingStr = "Time: " + timePlaying.ToString("mm':'ss'.'ff");
            timeCounter.text = timePlayingStr;
            yield return null;
        }
    }
}
