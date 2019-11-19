using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformFalling : MonoBehaviour
{

    public float fallDelay = 1f;
    public float respawnDelay = 5f;
    private Rigidbody2D rb2D;
    private PolygonCollider2D pc2D;
    private Vector3 start;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        pc2D = GetComponent<PolygonCollider2D>();
        start = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Invoke("Fall", fallDelay);
            Invoke("Respawn", fallDelay + respawnDelay);
        }
    }

    void Fall()
    {
        rb2D.isKinematic = false;
        pc2D.isTrigger = true;
    }

    void Respawn()
    {
        transform.position = start;
        rb2D.isKinematic = true;
        rb2D.velocity = Vector3.zero;
        pc2D.isTrigger = false;
    }
}
