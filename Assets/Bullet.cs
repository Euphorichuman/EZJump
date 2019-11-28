using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D rb2D;
    public float speed = 10f;
    public GameObject impactEffect;

    // Start is called before the first frame update
    void Start()
    {
        rb2D.velocity = transform.right * speed;
        Invoke("DestroySelf", .4f);
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Debug.Log(hitInfo.name);
        /*Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }*/

        Instantiate(impactEffect, transform.position, transform.rotation);
        DestroySelf();
    }

    private void DestroySelf()
    {
        Destroy(gameObject);
    }
}
