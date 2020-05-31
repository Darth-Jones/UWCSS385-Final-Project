using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearButton : MonoBehaviour
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
            Debug.Log("click Clear");
            keypadSystem.ClearKeyPadDisplay();
        }     
    }
}
