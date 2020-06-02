using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;
using System.Transactions;

public class EventLog : MonoBehaviour
{

    //[SerializeField]
    //private GameObject interactableText;
    //public bool readchedA = false;

    public LinkedList<string> checkPointText;
    private Dictionary<int, Event> eventList;

    // GameObject that flashes when new emails and objective hints appear
    public GameObject flashingText;
    public GameObject menuButton;
    public GameObject UICanvas;
    public GameObject emailControlList;
    public GameObject interactibleCanvas;

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
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //  showEmailCanvas = !showEmailCanvas;
            menuButton.GetComponent<MenuButtonController>().showEmailCanvas = false;
            UICanvas.SetActive(false);
        //    bodyCanvas.SetActive(showEmailCanvas);        
        }


        // THESE ARE FOR TESTING INTERACTIBLE CANVAS
        if (Input.GetKeyDown(KeyCode.L))
        { 

            TurnOnInteractibleCanvas("Press Space to Interact");
        }
        if (Input.GetKeyDown(KeyCode.K))
        {   

            TurnOffInteractibleCanvas();
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
        menuButton.GetComponent<MenuButtonController>().newEmail();
    }
    public void CreateEmail(int emailID, string headerText, string bodyText)
    {
        emailControlList.GetComponent<EmailListControl>().CreateEmail(emailID, headerText, bodyText);
        menuButton.GetComponent<MenuButtonController>().newEmail();

    }
    public void CreateEmail(int emailID, string headerText, string bodyText, string hintText)
    {
        emailControlList.GetComponent<EmailListControl>().CreateEmail(emailID, headerText, bodyText, hintText);
        menuButton.GetComponent<MenuButtonController>().newEmail();

    }

    public bool StepCompleted(int eventID, int stepID)
    {
        string flash = eventList[eventID].stepCompleted(stepID);
        if (flash != "")
        {
            FlashText(flash);
            newHintText(flash);
            menuButton.GetComponent<MenuButtonController>().newEventText();
        }
        return eventList[eventID].isComplete();
    }

    // checks if all steps in the event are completed
    public bool isComplete(int eventID)
    {
        if ( eventList.ContainsKey(eventID) )
        {
            return eventList[eventID].isComplete();
        }
        else
        {
            return false;
        }
      
    }

    public void FlashText(string flashText)
    {
        flashingText.GetComponent<TextFlashScript>().Flash(flashText);
    }
    
    // use this to turn on and off the interactible canvas when entering and exiting
    // an interacible object's collider
    public void TurnOnInteractibleCanvas(string newText)
    {
        
        Debug.Log("newText: " + newText);
        interactibleCanvas.SetActive(true);
        /*
        interactableText.GetComponent<Text>().text = newText;
        */
    }

    public void TurnOffInteractibleCanvas()
    {
        Debug.Log("Turning off canvas");
        interactibleCanvas.SetActive(false);
    }
}
