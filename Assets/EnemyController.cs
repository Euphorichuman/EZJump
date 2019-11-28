using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float maxSpeed = 4f;
    public float speed = 4f;
    public int health = 100;
    public GameObject deathEffect;
    private Rigidbody2D rb2D;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb2D.AddForce(Vector2.right * speed);
        float limitedSpeed = Mathf.Clamp(rb2D.velocity.x, -maxSpeed, maxSpeed);
        rb2D.velocity = new Vector2(limitedSpeed, rb2D.velocity.y);

        if (rb2D.velocity.x > -0.01f && rb2D.velocity.x < 0.01f)
        {
            speed = -speed;
            rb2D.velocity = new Vector2(speed, rb2D.velocity.y);

        }

        if (speed < 0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }

        if (speed > 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            col.SendMessage("EnemyNockBack", transform.position.x);
        }

        if (col.CompareTag("Bullet"))
        {
            health = health -5;

            if (health <= 0)
            {
                Die();
            }
        }
    }

    void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
