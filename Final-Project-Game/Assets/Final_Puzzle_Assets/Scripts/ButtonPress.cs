using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPress : MonoBehaviour
{
    private SpriteRenderer sr;
    private Color OGColor;
    public Color changeColor;
    private bool buttonPressed = false;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        
    }

    public void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!buttonPressed)
            {
                sr.material.color = changeColor;
                buttonPressed = true;
            }
            else {
                Invoke("ChangeColorBack", 0.1f);
            }
           
        }
    }

    private void ChangeColorBack()
    {

            sr.material.color = OGColor;
            buttonPressed = false;

    }
}
