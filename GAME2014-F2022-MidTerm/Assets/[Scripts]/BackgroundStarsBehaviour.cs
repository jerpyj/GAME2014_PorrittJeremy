using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundStarsBehaviour : MonoBehaviour
{
    public float horizontalSpeed;
    public Boundary boundary;
    

    // Update is called once per frame
    void Update()
    {
        Move();
        CheckBounds();
    }

    public void Move()
    {
        transform.position -= new Vector3(horizontalSpeed * Time.deltaTime, 0.0f);
    }

    public void CheckBounds()
    {
        if (transform.position.x < boundary.min)
        {
            ResetStars();
        }
    }

    public void ResetStars()
    {
        transform.position = new Vector2(boundary.max, 0.0f);
    }
}
