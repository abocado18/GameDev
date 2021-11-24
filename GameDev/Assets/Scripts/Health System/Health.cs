using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public int health;
    public int maxHealth;
    public string[] canDamagedBy;
    private void Start()
    {
        health = maxHealth;
    }


   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Damage>() != null)
        {
            bool canMakeDamage = false;

            foreach (var item in canDamagedBy)
            {
                if (item == collision.gameObject.tag)
                {
                    canMakeDamage = true;
                }
            }
            if (canMakeDamage)
            {
                health -= collision.gameObject.GetComponent<Damage>().damage;
                
            }

            if (health <= 0)
            {
                if(gameObject.tag == "Player")
                {
                    ScoreScript.scoreValue = 0;
                    Scene currentScene = SceneManager.GetActiveScene();
                    string name = currentScene.name;
                    SceneManager.LoadScene(name);
                }

                if(gameObject.tag == "Enemy")
                {
                    ScoreScript.scoreValue += 10;
                    Destroy(gameObject);
                    
                }
              
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Damage>() != null)
        {
            bool canMakeDamage = false;

            foreach (var item in canDamagedBy)
            {
                if(item == collision.gameObject.tag)
                {
                    canMakeDamage = true;
                }
            }
            if(canMakeDamage)
            {
                health -= collision.gameObject.GetComponent<Damage>().damage;
                print(collision.gameObject.name);
            }


            if (health <= 0)
            {
                if (gameObject.tag == "Player")
                {
                    ScoreScript.scoreValue = 0;
                    Scene currentScene = SceneManager.GetActiveScene();
                    string name = currentScene.name;
                    SceneManager.LoadScene(name);
                }

                if (gameObject.tag == "Enemy")
                {
                    ScoreScript.scoreValue += 10;
                    Destroy(gameObject);

                }

            }
        }
    }
}
