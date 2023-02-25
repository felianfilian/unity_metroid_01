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

    private int direction;
    private int currentPoint;
    private float waitcounter;

    void Start()
    {
        direction = 1;
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
            if(transform.position.y < patrolPoints[currentPoint].transform.position.y - 0.3f && rigidbody.velocity.y <0.1f)
            {
                rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpForce);
            }
        }
        else
        {
            rigidbody.velocity = new Vector2(0f, rigidbody.velocity.y);
            waitcounter -= Time.deltaTime;
            if(waitcounter <= 0)
            {
                waitcounter = waitAtPoint;
                currentPoint += direction;
                Debug.Log(direction);
                if (currentPoint >= patrolPoints.Length-1)
                {
                    direction = -1;
                }
                if(currentPoint == 0)
                {
                    direction = 1;
                }
            }
        }
    }
}
