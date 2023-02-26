using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    [HideInInspector]
    public int health;
    public int maxHealth = 10;
    
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
