using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public new Rigidbody2D rigidbody;

    public int damageAmount = 1;
    public float bulletSpeed = 13f;

    public GameObject bulletImpactEffect;

    private Vector2 moveDir;

    void Start()
    {
        moveDir = new Vector2(PlayerController.instance.transform.localScale.x, 0);
    }

    void Update()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.velocity = moveDir * bulletSpeed;        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyHealthController>().DamageEnemy(damageAmount);
        }
        Instantiate(bulletImpactEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

}
