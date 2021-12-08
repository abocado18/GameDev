using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    bool activated;
    bool canChange;
    bool canInteract;
    public GameObject door;
    public Transform lever;

    void Start()
    {
        activated = false;
        canChange = true;
    }

    private void Update()
    {
        if(canInteract)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (!activated && canChange)
                {
                    door.SetActive(false);
                    activated = true;
                    canChange = false;
                    lever.rotation = Quaternion.Euler(0f, 0f, -30.48f);
                    Invoke("SetChangeTrue", 1f);

                }

                else if (activated && canChange)
                {
                    door.SetActive(true);
                    activated = false;
                    canChange = false;
                    lever.rotation = Quaternion.Euler(0f, 0f, 30.48f);
                    Invoke("SetChangeTrue", 1f);
                }

            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            canInteract = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            canInteract = false;
        }
        
    }

    private void SetChangeTrue()
    {
        canChange = true;
    }
}
