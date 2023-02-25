using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public new Rigidbody2D rigidbody;
    public Transform[] patrolPoints;

    public float moveSpeed = 5f;
    public float waitAtPoint = 3f;
    public float jumpForce = 10f;
    
    private int currentPoint;
    private float waitcounter;

    void Start()
    {
        currentPoint = 0;
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
                transform.localScale = new Vector3(-1f, 1f, 1f);
            }
            else
            {
                rigidbody.velocity = new Vector2(-moveSpeed, rigidbody.velocity.y);
                transform.localScale = new Vector3(1f, 1f, 1f);
            }
        }
        else
        {
            rigidbody.velocity = new Vector2(0f, rigidbody.velocity.y);
            waitcounter -= Time.deltaTime;
            if(waitcounter <= 0)
            {
                waitcounter = waitAtPoint;
                currentPoint++;
                if(currentPoint >= patrolPoints.Length)
                {
                    currentPoint = 0;
                }
            }
        }
    }
}
