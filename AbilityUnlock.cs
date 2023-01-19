using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityUnlock : MonoBehaviour
{
    public bool canDoubleJump;
    public bool canDash;
    public bool canBall;
    public bool canBomb;


    private void OnTriggerEnter2D(Collider2D other)
    {   
        if(other.gameObject.CompareTag("Player"))
        {
            Debug.Log("test");
            AbilityTracker.instance.canDoubleJump = true;
        }
            
        Destroy(gameObject);
    }
}
