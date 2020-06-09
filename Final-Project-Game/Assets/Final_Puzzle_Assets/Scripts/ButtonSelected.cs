using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSelected : MonoBehaviour
{
    private SpriteRenderer sr;
    private Sprite OGSprite;
    public Sprite newSprite;

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
            sr.sprite = newSprite;

        }
    }

    public void OnSubmit()
    {
        sr.sprite = OGSprite;
    }
}

