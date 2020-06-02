using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionObject : MonoBehaviour
{
    [Header("Object Connections")]
    public GameObject interactable;
    public GameObject emailSystem;

    [Header("Interaction Options")]
    public bool displayObjectOnClick = false;
    public bool displayUIText = false;
    public string UIText;
    public bool createEmailOrEventOnTouch = false;
    public bool createEmail = false;
    public bool creatEvent = false;
    public bool repeatInteraction = false;
    private bool interactedWith = false;

    [Header("Requires Perquisite Event")]
    public bool requiresEventCheck = false;
    public int eventIDRequired;

    [Header("Email Creation Options")]
    public int emailID;
    public string emailHeader;
    public string emailBody;
    public string emailHintText;

    [Header("Event Creation Options")]
    public int eventID;
    public int stepCount;
    public string[] eventHintText;

    [Header("Event Completetion Options")]
    public bool completesEventStep;
    public int completeEventID;
    public int step;


    //Determines type of trigger by using string
    //Trigger Types: enter, exit, and click
    public void Triggered(string trigger)
    {
        eventCheck = true;

        if (requiresEventCheck)
		{
            eventCheck = emailSystem.GetComponent<EventLog>().IsCompleted(eventIDRequired);
		}
         

        if (!(interactedWith))
        {
            

            if (trigger == "enter")
            {
                Debug.Log("Interaction exit");
                if (displayUIText)
                    DisplayUIText();
                if (createEmailOrEventOnTouch && eventCheck)
                {
                    if (createEmail)
                        CreateEmail();

                    if (creatEvent)
                        CreateEvent();
                    interactedWith = true;
                }

            }
            else if (trigger == "exit")
            {
                Debug.Log("Interaction exit");
                if (displayUIText)
                    RemoveUIText();

                if (displayObjectOnClick)
                    RemoveObject();

            }
            else if (trigger == "click" && eventCheck)
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
        emailSystem.GetComponent<EventLog>().TurnOnInteractibleCanvas(UIText);
    }

    void RemoveUIText()
    {
        emailSystem.GetComponent<EventLog>().TurnOffInteractibleCanvas();
    }

    //Creates a new event for the objectives
    void CreateEvent()
    {
        emailSystem.GetComponent<EventLog>().CreateEvent(eventID, stepCount, eventHintText);
        Debug.Log("Event Created");
    }

    //Completes the given event step
    void CompleteEventStep()
    {
        if (completesEventStep)
        {
            emailSystem.GetComponent<EventLog>().StepCompleted(completeEventID, step);
            //completesEventStep = false;
        }
        Debug.Log("Step Completed");
    }

    //Creates an Email Object
    void CreateEmail()
    {
        if (createEmail)
        {
            emailSystem.GetComponent<EventLog>().CreateEmail(emailID, emailHeader, emailBody, emailHintText);
            //createEmail = false;
        }
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
