using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    int health;
    public int maxHealth;

    private void Start()
    {
        health = maxHealth;
    }


   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Damage>() != null)
        {
            health -= collision.gameObject.GetComponent<Damage>().damage;
            print(collision.gameObject.GetComponent<Damage>().damage);
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
