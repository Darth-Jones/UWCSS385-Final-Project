using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionObject : MonoBehaviour
{
    //Interaction Options
    public GameObject interactable;
    public bool displayObjectOnClick = false;
    public bool displayUIText = false;
    public string UIText;
    public bool createEmail = false;
    public bool creatEvent = false;
    public bool repeatInteraction = false;
    private bool interactedWith = false;

    

    public bool requiresEventAccomplishment = false;
    public int eventNumberRequired;

    //Email Creation Options
    public int emailID;
    public string emailHeader;
    public string emailBody;
    public string emailHintText;

    //Event Creation Options
    public int eventID;
    public int stepCount;
    public string[] eventHintText;

    //Event Completetion Options
    public bool completesEventStep;
    public int completeEventID;
    public int step;


    //Determines type of trigger by using string
    //Trigger Types: enter, exit, and click
    public void Triggered(string trigger)
    {
        
        if (!(interactedWith))
        {
            

            if (trigger == "enter")
            {
                if (displayUIText)
                    DisplayUIText();

            }
            else if (trigger == "exit")
            {
                if (displayUIText)
                    RemoveUIText();

                if (displayObjectOnClick)
                    RemoveObject();

            }
            else if (trigger == "click")
            {
                interactedWith = true;

                if (createEmail)
                    CreateEmail();

                if (creatEvent)
                    CreateEvent();

                if (completesEventStep)
                    CompleteEventStep();

                if (displayObjectOnClick)
                    DisplayObject();
            }
        }

        if (repeatInteraction)
        {
            interactedWith = false;
        }

    }

    //Displays Text on UI object 
    void DisplayUIText()
    {
        //need to implement UI Object to display
        Debug.Log("Press Space to Interact");
    }

    void RemoveUIText()
    {
        Debug.Log("Left Interaction Zone");
    }

    //Creates a new event for the objectives
    void CreateEvent()
    {
        Debug.Log("Event Created");
    }

    //Completes the given event step
    void CompleteEventStep()
    {
        Debug.Log("Step Completed");
    }

    //Creates an Email Object
    void CreateEmail()
    {
        Debug.Log("Email Created");
    }

    void DisplayObject()
    {
        interactable.SetActive(true);
    }

    void RemoveObject()
    {
        interactable.SetActive(false);
    }

}
