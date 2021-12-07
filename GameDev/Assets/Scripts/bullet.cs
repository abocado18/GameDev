using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    public string[] TagCanNotHit;
    bool canHit; 
    
    void Start()
    {
        canHit = true;
        rb.velocity = transform.right * speed;
        Destroy(gameObject, 3f);
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        foreach(string name in TagCanNotHit)
        {
            if(name == hitInfo.gameObject.tag)
            {
                canHit = false;
                break;
            }
        }

        if(canHit)
        {
            Debug.Log(hitInfo.name);

            Destroy(gameObject);
        //ScoreScript.scoreValue += 10;
        }
      
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if(!canHit)
        {
            canHit = true;
        }
    }
}
