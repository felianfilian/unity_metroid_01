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
            if(canDoubleJump == true)
            {
                AbilityTracker.instance.canDoubleJump = true;
            }
            if(canDash == true)
            {
                AbilityTracker.instance.canDash = true;
            }
            if (canBall == true)
            {
                AbilityTracker.instance.canBall = true;
            }
            if (canBomb == true)
            {
                AbilityTracker.instance.canBomb = true;
            }
            Destroy(gameObject);
        }
        
    }
}
