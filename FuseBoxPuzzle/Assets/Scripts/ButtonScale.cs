using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScale : MonoBehaviour
{
    [SerializeField] private Vector3 scaleUp = new Vector3(1.2f, 1.2f, 1.2f);
    private Vector3 scaleDown;

    // Start is called before the first frame update
    void Start()
    {
        //scaleUp 
        scaleDown = new Vector3(transform.localScale.x,
            transform.localScale.y, transform.localScale.z);
    }

    private void OnMouseOver()
    {
        transform.localScale = scaleUp;

    }

    private void OnMouseExit()
    {
        transform.localScale = scaleDown;
    }
}
