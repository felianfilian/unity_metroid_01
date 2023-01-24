using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Rigidbody2D rigidbody;
    public Transform[] patrolPoints;

    public float moveSpeed = 5f;
    public float waitAtPoint = 3f;
    public float jumpForce = 10f;
    
    private int currentPoint;
    private float waitcounter;

    void Start()
    {
        waitcounter = waitAtPoint;
    }

    // Update is called once per frame
    void Update()
    {
        if(Mathf.Abs(transform.position.x - patrolPoints[currentPoint].transform.position.x) > 0.2f)
        {
            if(transform.position.x < patrolPoints[currentPoint].transform.position.x)
            {
                rigidbody.velocity = new Vector2(moveSpeed, rigidbody.velocity.y);
            }
            else
            {
                rigidbody.velocity = new Vector2(-moveSpeed, rigidbody.velocity.y);
            }
        }
    }
}
