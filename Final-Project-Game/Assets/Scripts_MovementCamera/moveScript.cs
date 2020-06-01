using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class moveScript : MonoBehaviour
{

    public float playerSpeed;                   // speed
    Rigidbody2D rb2d;
    public Vector2 currentPos = new Vector2 (0,0);
    public float maxSpeed = 2;
    Vector2 movement;
    public Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        playerSpeed = .1f;
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);

        currentPos = this.transform.position;
        //Debug.Log(currentPos);
    }
    public void movePlayer() {

        if (movement.x != 0)
            {
                rb2d.velocity = new Vector2(Math.Min(maxSpeed, rb2d.velocity.x + (movement.x * playerSpeed)), Math.Min(maxSpeed,(rb2d.velocity.y)));
            }

        if (movement.y != 0)
        {
            rb2d.velocity = new Vector2(Math.Min(maxSpeed, rb2d.velocity.x), Math.Min(maxSpeed, (rb2d.velocity.y + (movement.y * playerSpeed))));
        }

        if (rb2d.velocity.x < -maxSpeed) {
            rb2d.velocity = new Vector2( - maxSpeed, rb2d.velocity.y);
        }

        if (rb2d.velocity.y < -maxSpeed) {
            rb2d.velocity = new Vector2( rb2d.velocity.x, -maxSpeed);
        }
    }

    private void FixedUpdate()
    {
        movePlayer();
    }
}
