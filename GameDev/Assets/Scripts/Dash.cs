using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{

    public float dashForce;
    public float dashForceTimer;
    public float startTimer;
    bool canDash;
    bool isDashing;
    int direction;
    // Start is called before the first frame update
    void Start()
    {
        canDash = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift) && !GetComponent<PlayerMovement>().isGrounded && Mathf.Abs(GetComponent<PlayerMovement>().horizontal) != 0 && canDash)
        {
            isDashing = true;
            canDash = false;
            dashForceTimer = startTimer;
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            direction = (int)GetComponent<PlayerMovement>().horizontal;
        }

        if(isDashing)
        {
            GetComponent<PlayerMovement>().enabled = false;
            GetComponent<Rigidbody2D>().velocity = transform.right * direction * dashForce;

            dashForceTimer -= Time.deltaTime;

            if(dashForceTimer < 0)
            {
                isDashing = false;
                GetComponent<PlayerMovement>().enabled = true;
            }
           
        }
         if(GetComponent<PlayerMovement>().isGrounded)
            {
                canDash = true;
            }
    }
}
