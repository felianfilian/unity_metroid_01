using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    public static PlayerHealthController instance;

    // [HideInInspector]
    public int health;
    public int maxHealth = 10;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        health = maxHealth;
    }

    public void DamagePlayer(int damageAmount)
    {
        health -= damageAmount;
        if(health <= 0)
        {
            health = 0;
            gameObject.SetActive(false);
        }
    }
}
