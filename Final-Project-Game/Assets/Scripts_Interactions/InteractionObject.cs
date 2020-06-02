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
    public bool removeObjectOnClick = true;
    public bool displayUIText = false;
    public string UIText;
    public bool interactOnTouch = false;
    public bool createEmail = false;
    public bool creatEvent = false;
    public bool repeatInteraction = false;
    private bool interactedWith = false;

    [Header("Enviroment Effects")]
    public bool turnsOffLights = false;
    public bool turnsOnLights = false;
    public bool cameraShake = false;

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
        bool eventCheck = true;

        if (requiresEventCheck)
		{
            eventCheck = emailSystem.GetComponent<EventLog>().isComplete(eventIDRequired);
		}
         

        if (!(interactedWith))
        {
            

            if (trigger == "enter")
            {
                Debug.Log("Interaction Enter");
                if (displayUIText)
                    DisplayUIText();
                if (interactOnTouch && eventCheck)
                {
                    if (createEmail)
                        CreateEmail();

                    if (creatEvent)
                        CreateEvent();

                    if (turnsOnLights)
                        Debug.Log("Lights On");

                    if (turnsOffLights)
                        Debug.Log("Lights On");

                    if (cameraShake)
                        Debug.Log("Camera Shake");

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
            else if (trigger == "click" && eventCheck && !interactedWith)
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

                if (removeObjectOnClick)
                    RemoveObject();
                

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
        //Debug.Log(UIText);
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
