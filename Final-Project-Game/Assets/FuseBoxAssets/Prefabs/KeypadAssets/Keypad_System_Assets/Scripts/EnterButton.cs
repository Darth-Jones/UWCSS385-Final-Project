using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterButton : MonoBehaviour
{
    private KeypadSystem keypadSystem;

    private void Start()
    {
        keypadSystem = gameObject.GetComponentInParent < KeypadSystem > ();
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("click Enter");
            keypadSystem.EnterKeyPressed();
        }     
    }
}
