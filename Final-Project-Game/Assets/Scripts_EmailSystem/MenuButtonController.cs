using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuButtonController : MonoBehaviour
{

    public bool showEmailCanvas;
    public GameObject UICanvas;
    public Text buttonText;
    public void OnClick()
    {
        showEmailCanvas = !showEmailCanvas;
        UICanvas.SetActive(showEmailCanvas);
        buttonText.text = "Menu";
        //    bodyCanvas.SetActive(showEmailCanvas);  
        
    }


    public void newEmail()
    {
        buttonText.text = "Menu\nNew Email";
    }

    public void newEventText()
    {
        Debug.Log("menu button new event");
        buttonText.text = "Menu\nNew Objective";
    }
}
