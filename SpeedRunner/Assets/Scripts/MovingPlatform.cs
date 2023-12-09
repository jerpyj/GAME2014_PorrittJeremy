using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float speed = 1.0f;
    public float maxDistance = 5.0f;
    public bool moveVertically = false;

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
        speed = Random.Range(speed -0.50f, speed +0.50f);
    }

    void FixedUpdate()
    {
        float movement = Mathf.Sin(Time.time * speed) * maxDistance * Time.deltaTime;

        if (moveVertically)
        {
            // Move up and down
            transform.position = startPosition + new Vector3(0, movement, 0);
        }
        else
        {
            // Move left and right
            transform.position = startPosition + new Vector3(movement, 0, 0);
        }
    }
}
