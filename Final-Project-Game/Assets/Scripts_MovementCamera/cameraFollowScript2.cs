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
    public Vector3 expectedPos;
    // Start is called before the first frame update


    void Start()
    {
        playerMovement = player.GetComponent<moveScript>();
        expectedPos = new Vector3(player.transform.position.x, player.transform.position.y, -10);
        transform.position = expectedPos;
        rb2d = GetComponent<Rigidbody2D>();
        playerPos = playerMovement.currentPos;
        
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = playerMovement.currentPos;
        
        rb2d.velocity = new Vector2(-((transform.position.x - playerPos.x) * rubberBandNess), -((transform.position.y - playerPos.y) * rubberBandNess)); 
        expectedPos = new Vector2(transform.position.x + rb2d.velocity.x , (transform.position.y + rb2d.velocity.y));    
        //Debug.Log(transform.position);
    }
    public bool needsReadjusting(Vector2 playerPos) {
        if (((transform.position.y  + Looseness) < playerPos.y) | ((transform.position.y - Looseness) > playerPos.y) | ((transform.position.x + Looseness) < playerPos.x) | (( transform.position.x - Looseness) > playerPos.x)) {
            Debug.Log("needsReadjusting");
            return true;

        }
        else return false;
    }
}
