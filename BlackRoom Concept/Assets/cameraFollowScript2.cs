using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollowScript2 : MonoBehaviour
{

    public GameObject player;
    public float Looseness;
    public float rubberBandNess;

    public Vector2 playerPos;

    private moveScript playerMovement;
    Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        playerMovement = player.GetComponent<moveScript>();
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10);
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = playerMovement.currentPos;
        rb2d.velocity = new Vector2(-(transform.position.x - playerPos.x * rubberBandNess), -(transform.position.y - playerPos.y * rubberBandNess));

        /*
        playerPos = playerMovement.currentPos;
        Debug.Log("yPos+Loose" + (transform.position.y  + Looseness));
        Debug.Log("yPos-Loose" + (transform.position.y  - Looseness));
        Debug.Log("PlayerPos" + playerPos.y);
        Debug.Log("Velocity" + rb2d.velocity);
        if (needsReadjusting(playerPos)) {
            if ((transform.position.y  + Looseness) < playerPos.y) {
                rb2d.velocity = new Vector2(rb2d.velocity.x, rb2d.velocity.y + (Vector2.up.y * playerMovement.mHeroSpeed*.2f * rubberBandNess));
                Debug.Log("MovingUp");
            }
            else if ((transform.position.y - Looseness) > playerPos.y) {
                rb2d.velocity = new Vector2(rb2d.velocity.x, rb2d.velocity.y + (Vector2.down.y * playerMovement.mHeroSpeed*.2f * rubberBandNess));
                Debug.Log("MovingDown");
            }
            if ((transform.position.x + Looseness) < playerPos.x) {
                rb2d.velocity = new Vector2( rb2d.velocity.x + (Vector2.left.x * -playerMovement.mHeroSpeed*.2f * rubberBandNess), rb2d.velocity.y);
                Debug.Log("MovingRight");
            }
            else if ((transform.position.x - Looseness) > playerPos.x) {
                rb2d.velocity = new Vector2( rb2d.velocity.x + (Vector2.right.x * -playerMovement.mHeroSpeed*.2f * rubberBandNess), rb2d.velocity.y);
                Debug.Log("MovingLeft");
            }
        }
        else {
            rb2d.velocity = new Vector2(rb2d.velocity.x * .8f, rb2d.velocity.y * .8f);
        }
        */
        
        
    }
    public bool needsReadjusting(Vector2 playerPos) {
        if (((transform.position.y  + Looseness) < playerPos.y) | ((transform.position.y - Looseness) > playerPos.y) | ((transform.position.x + Looseness) < playerPos.x) | (( transform.position.x - Looseness) > playerPos.x)) {
            Debug.Log("needsReadjusting");
            return true;

        }
        else return false;
    }
}
