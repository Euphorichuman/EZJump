using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadEffect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        Invoke("DestroySelf", .2f);

    }

    private void DestroySelf()
    {
        Destroy(gameObject);
    }
}
