using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TileScript : MonoBehaviour
{
    private Vector3 scaleUp;
    private Vector3 scaleDown;
    private Text number;

    // Start is called before the first frame update
    void Start()
    {
        scaleUp = new Vector3(2f, 2f, 2f);
        scaleDown = new Vector3(transform.localScale.x,
            transform.localScale.y, transform.localScale.z);
    }

    private void OnMouseOver()
    {
        transform.localScale = scaleUp;
        number.text = "";

    }

    private void OnMouseExit()
    {
        transform.localScale = scaleDown;
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0)) {
            //Instantiate keypad
            number.text = "this is a number";
        }
    }
}
