using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAdd : MonoBehaviour
{
    public int buttonNumber = 0;
    private KeypadSystem keypadSystem;

    private void Start()
    {
        keypadSystem = gameObject.GetComponentInParent < KeypadSystem > ();
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("click " + buttonNumber);
            keypadSystem.ProcessNumberPress(buttonNumber);
        }     
    }
}
