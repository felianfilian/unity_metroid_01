using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityTracker : MonoBehaviour
{
    public static AbilityTracker instance;

    public bool canDoubleJump;
    public bool canDash;
    public bool canBall;
    public bool canBomb;

    private void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
