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
    private bool movement = true;
    private SpriteRenderer spr;
    private float hp, maxHp = 100f;
    Object bulletRef;
    public GameObject healthBar;


    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        bulletRef = Resources.Load("Bullet");
        anim = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();
        healthBar = GameObject.Find("HealthBar");

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

        if (Input.GetKeyDown(KeyCode.X))
        {
            anim.Play("Player_Fire");
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
        if (!movement) horizontal = 0;
        rb2D.AddForce(Vector2.right * speed * horizontal);

        float limitedSpeed = Mathf.Clamp(rb2D.velocity.x, -maxSpeed, maxSpeed);
        rb2D.velocity = new Vector2(limitedSpeed, rb2D.velocity.y);

        if (horizontal > 0.1f)
        {
            transform.localRotation = new Quaternion(0f, 0f, 0f, 0f);
        }

        if (horizontal < -0.1f)
        {
            transform.localRotation = new Quaternion(0f, 180f, 0f, 0f);
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
        transform.position = new Vector3(-6, 0, 0);
    }

    public void EnemyNockBack(float enemyPosX)
    {
        healthBar.SendMessage("TakeDamage", 20f);
        hp = hp - 20f;
        if (hp <= 0)
        {
            Invoke("Die", 0.7f);
        }


        jump = true;

        float side = Mathf.Sign(enemyPosX - transform.position.x);
        rb2D.AddForce(Vector2.left * side * jumpForce, ForceMode2D.Impulse);

        movement = false;

        Invoke("EnableMovement", 0.7f);
        spr.color = Color.red;
    }

    void EnableMovement()
    {
        movement = true;
        spr.color = Color.white;
    }

    void Die()
    {
        OnBecameInvisible();
        hp = maxHp;
        healthBar.SendMessage("RespawnHealth");
    }

}
