using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Goal : MonoBehaviour
{
    TimerControllerScript mytimer;
    public GameObject winPanel;
    public GameObject canvas;
    bool won = false;

    void Start() {
        mytimer = GameObject.Find("TimerCounterText").GetComponent<TimerControllerScript>();
    }
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && !won)
        {
            //print("You win");
            won = true;
            ScoreScript.scoreValue += (int)Math.Floor(500/mytimer.timeInSeconds);
            GameObject.Find("Player").GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            GameObject.Find("Player").GetComponent<PlayerMovement>().enabled = false;
            StartCoroutine("showWinPanel");
        }
    }

    IEnumerator showWinPanel()
    {
        yield return new WaitForSeconds(2f);
        canvas.SetActive(false);
        Instantiate(winPanel);
    }
}
