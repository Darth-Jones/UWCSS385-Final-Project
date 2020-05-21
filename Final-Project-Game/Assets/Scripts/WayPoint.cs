using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    public bool visible = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Toggles bool visble
        if (Input.GetKeyDown(KeyCode.H))
            visible = !visible;

        SpriteRenderer spritRend = GetComponent<SpriteRenderer>();

        spritRend.enabled = visible;
    }
}
