using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFlyController : MonoBehaviour
{
    public Animator animator;

    public float chaseRange = 10f;
    public float moveSpeed = 5f;
    public float turnSpeed = 5f;
    
    private bool isChasing;
    private Transform player;

    void Start()
    {
        player = PlayerHealthController.instance.transform;
    }

 
    void Update()
    {
        FlyerMove();
    }

    public void FlyerMove()
    {
        if (!isChasing)
        {
            if (Vector3.Distance(transform.position, player.position) < chaseRange)
            {
                isChasing = true;
            }
        }
        else
        {
            if (player.gameObject.activeSelf)
            {
                Vector3 direction = transform.position - player.position;
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                Quaternion targetRot = Quaternion.AngleAxis(angle, Vector3.forward);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, turnSpeed * Time.deltaTime);
                transform.position += transform.right * moveSpeed * Time.deltaTime;
                animator.SetBool("isChasing", isChasing);
            }
        }
    }
}
