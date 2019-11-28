using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image health;
    float hp, maxHp = 100f;

    // Start is called before the first frame update
    void Start()
    {
        hp = maxHp;
    }

    public void TakeDamage(float amount)
    {
        hp = Mathf.Clamp(hp - amount, 0, maxHp);
        health.transform.localScale = new Vector2(hp/maxHp, 1);
    }

    public void RespawnHealth()
    {
        health.transform.localScale = new Vector2(1, 1);
    }
}
