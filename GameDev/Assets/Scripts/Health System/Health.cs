using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    int health;
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
                print(collision.gameObject.GetComponent<Damage>().damage);
            }

            if (health <= 0)
            {
                if(gameObject.tag == "Player")
                {
                    Scene currentScene = SceneManager.GetActiveScene();
                    string name = currentScene.name;
                    SceneManager.LoadScene(name);
                }
                Destroy(gameObject);
                ScoreScript.scoreValue += 10;
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
                Destroy(gameObject);
            }
        }
    }
}
