using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPress : MonoBehaviour
{
    private SpriteRenderer sr;
    private Sprite OGSprite;
    public Sprite newSprite;
    private bool buttonPressed = false;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        OGSprite = sr.sprite;
        
    }

    public void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!buttonPressed)
            {
                sr.sprite = newSprite;
            }
           
        }
    }

    public void OnMouseUp()
    {
        if (Input.GetMouseButtonUp(0)) {
            sr.sprite = OGSprite;
        }
    }
}
