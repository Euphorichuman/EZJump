using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float maxSpeed = 2f;
    public float speed = 15f;
    public bool grounded;
    public float jumpForce = 9f;
    private Rigidbody2D rb2D;
    private Animator anim;
    private bool jump; 


    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("Speed", Mathf.Abs(rb2D.velocity.x));
        anim.SetBool("Grounded", grounded);

        if (Input.GetKeyDown(KeyCode.UpArrow) && grounded)
        {
            grounded = false;
            jump = true;
        }
    }

    void FixedUpdate()
    {
        Vector3 fixedVelocity = rb2D.velocity;
        fixedVelocity.x *= 0.75f;

        if (grounded)
        {
            rb2D.velocity = fixedVelocity;
        }

        float horizontal = Input.GetAxis("Horizontal");
        rb2D.AddForce(Vector2.right * speed * horizontal);

        float limitedSpeed = Mathf.Clamp(rb2D.velocity.x, -maxSpeed, maxSpeed);
        rb2D.velocity = new Vector2(limitedSpeed, rb2D.velocity.y);

        if (horizontal > 0.1f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }

        if (horizontal < -0.1f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }

        if (jump)
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, 0);
            rb2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jump = false;
        }

        Debug.Log(rb2D.velocity.y);

    }

    private void OnBecameInvisible()
    {
        transform.position = new Vector3(-2, 0, 0);
    }
}
