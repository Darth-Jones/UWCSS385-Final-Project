using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class followPlayer : MonoBehaviour
{

    
    public GameObject player;

    public Vector2 playerPos;
    private moveScript playerMovement;
    // Start is called before the first frame update
    void Start()
    {
        
        playerMovement = player.GetComponent<moveScript>();
        playerPos = playerMovement.currentPos;
        transform.position = playerPos;
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = playerMovement.currentPos;
        transform.position = playerPos;
    }
}
