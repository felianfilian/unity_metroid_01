using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform minHeight;
    public Transform maxHeight;

    private float halfHeight;

    private void Start()
    {
        halfHeight = Camera.main.orthographicSize;
    }

    void Update()
    {
        Vector3 playerPos = PlayerController.instance.transform.position;
        float minPos = minHeight.position.y + halfHeight;
        float maxPos = maxHeight.position.y - halfHeight;
        transform.position = new Vector3(playerPos.x, Mathf.Clamp(playerPos.y, minPos, maxPos), playerPos.z  -10);
    }
}
