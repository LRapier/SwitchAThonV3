using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public Rigidbody rb;
    public PlayerMovement movement;
    public Vector3 startPos;

    public void Start()
    {
        startPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }

    public void Update()
    {
        if (!movement.enabled)
            Invoke("ResetPosition", 2f);
    }

    public void ResetPosition()
    {
        rb.velocity = new Vector3(0f, 0f, 0f);
        rb.angularVelocity = new Vector3(0f, 0f, 0f);
        transform.position = startPos;
        transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
    }
}
