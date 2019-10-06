using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;

public class PlayerController : MonoBehaviour
{
    public Speed speed;
    public Boundary boundary;
    public GameController gameController;

    private AudioSource _crash1;
    private AudioSource _crash2;
    private AudioSource _powerup;    

    // Start is called before the first frame update
    void Start()
    {
        _crash1 = gameController.audioSources[(int)SoundClip.CRASHE1];
        _crash2 = gameController.audioSources[(int)SoundClip.CRASHE2];
        _powerup = gameController.audioSources[(int)SoundClip.POWERUP];
    }
    // Update is called once per frame
    void Update()
    {
        Move();
        BoundaryCheck();
    }
    public void Move()
    {
        Vector2 newPosition = transform.position;
        if (Input.GetAxis("Vertical") > 0.0f)
        {
            newPosition += new Vector2(0.0f, speed.max);
        }

        if (Input.GetAxis("Vertical") < 0.0f)
        {
            newPosition += new Vector2(0.0f, speed.min);
        }
        transform.position = newPosition;
    }

    public void BoundaryCheck()
    {
        if (transform.position.y > boundary.Top)
        {
            transform.position = new Vector2(transform.position.x, boundary.Top);
        }
        if (transform.position.y < boundary.Bottom)
        {
            transform.position = new Vector2(transform.position.x, boundary.Bottom);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.gameObject.tag)
        {
            case "Enemy1":
                _crash1.Play();
                gameController.Lives -= 5;
                break;
            case "Enemy2":
                _crash2.Play();
                gameController.Lives -= 10;
                break;
            case "PowerUp":
                _powerup.Play();
                gameController.Score += 10;
                gameController.Lives += 5;
                break;
        }
    }
}
