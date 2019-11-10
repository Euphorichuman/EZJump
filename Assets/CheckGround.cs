using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGround : MonoBehaviour
{
    private PlayerController player;
    private Rigidbody2D rb2D;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponentInParent<PlayerController>();
        rb2D = GetComponentInParent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Plataform")
        {
            player.transform.parent = col.transform;
            player.grounded = true;
        }
    }

    void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground") {
            player.grounded = true;
        }

        if (col.gameObject.tag == "Plataform")
        {
            player.transform.parent = col.transform;
            player.grounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground") {
        player.grounded = false;
        }

        if (col.gameObject.tag == "Plataform")
        {
            player.transform.parent = null;
            player.grounded = false;
        }
    }
}
