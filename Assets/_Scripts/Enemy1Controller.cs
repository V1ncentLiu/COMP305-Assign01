using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;

public class Enemy1Controller : MonoBehaviour
{
    public float horizontalSpeed = 0.05f;
    public Boundary boundary;

    // Start is called before the first frame update.
    void Start()
    {
        //Reset();
    }
    // Update is called once per frame.
    void Update()
    {
        Move();
        BoundaryCheck();
    }
    //This method moves the sky to left by horizontalSpeed.
    void Move()
    {
        Vector2 newPosition = new Vector2(horizontalSpeed, 0.0f);
        Vector2 currentPosition = transform.position;
        currentPosition -= newPosition;
        transform.position = currentPosition;
    }
    //This method resets the position of the sky.
    void Reset()
    {
        float randomYPosition = Random.Range(boundary.Bottom, boundary.Top);
        transform.position = new Vector2(boundary.Right, randomYPosition);
    }
    //This method checks if the sky meets the reset point.
    void BoundaryCheck()
    {
        if (transform.position.x <= boundary.Left)
        {
            Reset();
        }
    }
}
