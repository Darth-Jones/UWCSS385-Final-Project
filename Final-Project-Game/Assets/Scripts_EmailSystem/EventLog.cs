using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;
using System.Transactions;

public class EventLog : MonoBehaviour
{

    //public bool readchedA = false;

    public LinkedList<string> checkPointText;
    private Dictionary<int, Event> eventList;

    public GameObject flashingText;

    public GameObject UICanvas;
    public GameObject emailControlList;


   // public GameObject emailCanvas;
    public GameObject bodyCanvas;
    public GameObject checkPointCanvas;

    private bool showEmailCanvas;


    public int currentID = -1;
    private string a;
    // Start is called before the first frame update
    void Start()
    {
        showEmailCanvas = false;
        checkPointText = new LinkedList<string>();
        checkPointText.AddFirst("");
        eventList = new Dictionary<int, Event>();

        a = Application.dataPath;

    }



    // Update is called once per frame
        void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            showEmailCanvas = !showEmailCanvas;
            UICanvas.SetActive(showEmailCanvas);
        //    bodyCanvas.SetActive(showEmailCanvas);        
        }
    }

    public void newHintText(string text)
    {
        checkPointText.AddFirst(text);
        checkPointCanvas.GetComponent<CheckPointCanvasController>().newText(text);
            a = text;
       
    }

    // Creates a new event based on the given eventID
    public void CreateEvent(int eventID)
    {
        eventList.Add(eventID, new Event(eventID));
    }

    public void CreateEvent(int eventID, int stepCount, string[] hintText)
    {
        eventList.Add(eventID, new Event(eventID, stepCount, hintText));
    }

    public void CreateEmail(int emailID)
    {
        emailControlList.GetComponent<EmailListControl>().CreateEmail(emailID);
    }
    public void CreateEmail(int emailID, string headerText, string bodyText)
    {
        emailControlList.GetComponent<EmailListControl>().CreateEmail(emailID, headerText, bodyText);
    }
    public void CreateEmail(int emailID, string headerText, string bodyText, string hintText)
    {
        emailControlList.GetComponent<EmailListControl>().CreateEmail(emailID, headerText, bodyText, hintText);
    }

    public bool StepCompleted(int eventID, int stepID)
    {
        string flash = eventList[eventID].stepCompleted(stepID);
        if (flash != "")
        {
            FlashText(flash);
            newHintText(flash);
        }
        return eventList[eventID].isComplete();
    }
    // checks if all steps in the event are completed
    public bool isComplete(int eventID)
    {
        return eventList[eventID].isComplete();
    }

    public void FlashText(string flashText)
    {
        flashingText.GetComponent<TextFlashScript>().Flash(flashText);
    }
    
}
