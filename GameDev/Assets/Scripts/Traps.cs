using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Traps : MonoBehaviour
{
    public bool instakill;
    public int damage;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if(instakill)
            {
                    ScoreScript.scoreValue = 0;
                    Scene currentScene = SceneManager.GetActiveScene();
                    string name = currentScene.name;
                    SceneManager.LoadScene(name);
            }
            else
            {
                collision.gameObject.GetComponent<Health>().health -= damage;

                if(collision.gameObject.GetComponent<Health>().health <= 0)
                {
                    ScoreScript.scoreValue = 0;
                    Scene currentScene = SceneManager.GetActiveScene();
                    string name = currentScene.name;
                    SceneManager.LoadScene(name);
                }
            }
        }
    }
}
