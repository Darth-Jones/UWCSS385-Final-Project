using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class moveScript : MonoBehaviour
{

    public float mHeroSpeed;                   // speed
    private const float kHeroRotateSpeed = 1f;  // rotate speed
    Rigidbody2D rb2d;
    public float horizontalSpeed;

    public Vector2 currentPos = new Vector2 (0,0);
    public float verticalSpeed;
    
    private float rotationX;
    public float maxSpeed = 2;


    // Start is called before the first frame update
    void Start()
    {
        mHeroSpeed = .1f;
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
            {
                rb2d.velocity = new Vector2(Math.Min(maxSpeed,rb2d.velocity.x + (transform.up.x * mHeroSpeed)), Math.Min(maxSpeed,(rb2d.velocity.y + (transform.up.y * mHeroSpeed))));
            }
        else if (Input.GetKey(KeyCode.DownArrow))
            {
                rb2d.velocity = new Vector2(Math.Min(maxSpeed, rb2d.velocity.x - (transform.up.x * mHeroSpeed)),Math.Min(maxSpeed, rb2d.velocity.y - (transform.up.y * mHeroSpeed)));
            }
        if (rb2d.velocity.x < -maxSpeed) {
            rb2d.velocity = new Vector2( - maxSpeed, rb2d.velocity.y);
        }
        if (rb2d.velocity.y < -maxSpeed) {
            rb2d.velocity = new Vector2( rb2d.velocity.x, -maxSpeed);
        }

        if (Input.GetKey(KeyCode.A))
            {
                rotationX = 2;
            }
        else if (Input.GetKey(KeyCode.D))
            {
                rotationX = -2;
            }
        else
            {
                rotationX = 0;
            }


        //Move the Hero forward

        //Rotate the hero based on if a button is pressed
        transform.Rotate(0, 0, rotationX * kHeroRotateSpeed);
        horizontalSpeed = rb2d.velocity.x;
        verticalSpeed = rb2d.velocity.y;

        currentPos = this.transform.position;
        Debug.Log(currentPos);
    }
}
