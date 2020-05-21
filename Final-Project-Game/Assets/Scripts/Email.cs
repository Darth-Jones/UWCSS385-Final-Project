using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using JetBrains.Annotations;
using UnityEngine.UI;

public class Email 
{

    public string headerText;
    public string bodyText;
    public string hintText;
    public bool hasHintText;

    public int emailID;
    public bool questFinished;
    public GameObject flashingTextCanvas;
    public GameObject bodyCanvas;

    public Email(int emailID) 
    {

    

        this.emailID = emailID;
        string path = Application.dataPath + "/Text/questObj" + emailID + ".txt";
        Debug.Log(path);
        string questText = File.ReadAllText(path);
        Debug.Log(questText);
        string[] questInfo = questText.Split('|');
        // int numberOfInt32.TryParse(TextBoxD1.Text, out x);
        // for (int i = 1; i < int.TryParse(questInfo[0]) + 1; i++)
        // {
        headerText = questInfo[0];
        bodyText = questInfo[1];
        hasHintText = false;
        int hintTextValue = int.Parse(questInfo[2]);
        if (hintTextValue > 0)
        {
            hasHintText  = true;
            hintText = questInfo[3];
        }
        else
        {
            questFinished = true;
        }

        


        Debug.Log("Asdfa" + headerText);
        flashingTextCanvas = GameObject.Find("FlashingTextCanvas");
        bodyCanvas = GameObject.Find("BodyCanvas");


        flashingTextCanvas.GetComponentInChildren<TextFlashScript>().Flash("NEW EMAIL");
    }

    public Email(int emailID, string header, string body, string hintText)
    {
        this.emailID = emailID;
        headerText = header;
        bodyText = body;
        hasHintText = true;
        this.hintText = hintText;
        flashingTextCanvas = GameObject.Find("FlashingTextCanvas");
        bodyCanvas = GameObject.Find("BodyCanvas");
    }

    public Email(int emailID, string header, string body)
    {
        this.emailID = emailID;
        headerText = header;
        bodyText = body;
        hasHintText = false;
        this.hintText = "";
        flashingTextCanvas = GameObject.Find("FlashingTextCanvas");
        bodyCanvas = GameObject.Find("BodyCanvas");
    }

    public bool stepCompleted()
    {
      //  Debug.Log("body text here:" + bodyText);
  //      bodyCanvas.GetComponentInChildren<Text>().text = bodyText;   //GetComponentOfChild<Text>().text = 

        if (hasHintText)
        {
            if (!questFinished)
            {
                Debug.Log("stepCompleted part");
                GameObject.Find("Canvas2").transform.GetChild(0).gameObject.SetActive(true);
                Debug.Log("starting flash");
                GameObject.Find("FlashingTextCanvas").GetComponent<TextFlashScript>().Flash(hintText);
                GameObject.Find("EventTracker").GetComponent<EventLog>().newText(hintText, emailID);

                questFinished = true;
            }
               
            return true;
        }

        return false;
    }
}
