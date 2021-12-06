using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    public GameObject timer;

    bool won = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && !won)
        {
            timer = GameObject.Find("TimerCounterText");

            print("You win");
            won = true;
            if (timer != null)
            {
                int timeInSeconds = Convert.ToInt32(timer.GetComponent<TimerControllerScript>().timeInSeconds);
                ScoreScript.scoreValue = ScoreScript.scoreValue + Convert.ToInt32(1200 / timeInSeconds);
                timer.GetComponent<TimerControllerScript>().EndTimer();
                GameManager.setScore(ScoreScript.scoreValue);
                SceneManager.LoadScene(2);
            }
            else {
                print("false");
            }
        }
    }
}
