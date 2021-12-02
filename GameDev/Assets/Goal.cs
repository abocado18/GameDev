using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    bool won = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && !won)
        {
            print("You win");
            won = true;
            //Add Score Script here
        }
    }
}
