using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOverTime : MonoBehaviour
{
    public float lifetime = 0.75f;

    void Start()
    {
        Destroy(gameObject, lifetime);
    }

 
}
