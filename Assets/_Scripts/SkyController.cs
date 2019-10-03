using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyController : MonoBehaviour
{
    public float horizontalSpeed = 0.1f;
    public float resetPosition = 4.5f;
    public float resetPoint = -4.5f;

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
        transform.position = new Vector2(resetPosition, 0.0f);
    }
    //This method checks if the sky meets the reset point.
    void BoundaryCheck()
    {
        if (transform.position.x <= resetPoint)
        {
            Reset();
        }
    }
}



