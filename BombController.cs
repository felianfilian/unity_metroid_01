using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour
{
    public float timeToExplode = 0.5f;
    public GameObject explosion;

    void Start()
    {
        
    }

    void Update()
    {
           timeToExplode -= Time.deltaTime;
        if(timeToExplode <= 0)
        {
            if(explosion != null)
            {
                Instantiate(explosion, transform.position, transform.rotation);
            }
            Destroy(gameObject);
        }
    }
}
