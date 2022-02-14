using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    Vector2 mousePos;
    public float gravityScale;
    public float runSpeed;
    public float jumpForce;
    public string ground;
    GameObject gun;
    Rigidbody2D rb;
    public float horizontal;
    public bool isGrounded;
    bool jump;
    bool cutJump;
    // Start is called before the first frame update
    void Start()
    {
        gun = GameObject.Find("Gun");
        rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        rb.gravityScale = gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal") * runSpeed;

        if(isGrounded && Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

        if(!isGrounded && Input.GetButtonUp("Jump"))
        {
            if(rb.velocity.y > 0)
            {
                cutJump = true;
            }

        }

        //Gun Rotation
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 lookDir = mousePos - rb.position;

        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;

        gun.transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2 (horizontal, rb.velocity.y);

        if(jump == true)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jump = false;
        }

        if(cutJump == true)
        {
            cutJump = false;
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
            
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == ground)
        {
            isGrounded = true;
        }
    }
    
    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == ground)
        {
            isGrounded = false;
        }
    }


}
