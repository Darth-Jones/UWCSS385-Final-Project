using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionObject : MonoBehaviour
{
    [Header("Object Connections")]
    public GameObject interactable;
    public GameObject emailSystem;
    public GameObject interactionCanvas;

    [Header("Interaction Options")]
    public bool displayObjectOnClick = false;
    public bool removeObjectOnClick = false;
    public bool removeInteractionOnClick = false;
    public bool displayUIText = false;
    public bool displayAltUIText = false;
    public string UIText;
    public string UIAltText;
    public bool interactOnTouch = false;
    public bool repeatInteraction = false;

    [Header("Enviroment Effects")]
    public bool turnsOffLights = false;
    public bool turnsOnLights = false;
    public bool cameraShake = false;
    public GameObject darkness;

    [Header("Requires Perquisite Event")]
    public bool requiresEventCheck = false;
    public int eventIDRequired;

    [Header("Email Creation Options")]
    public bool createEmail = false;
    public int emailID;
    public string emailHeader;
    public string emailBody;
    public string emailHintText;

    [Header("Event Creation Options")]
    public bool creatEvent = false;
    public int eventID;
    public int stepCount;
    public string[] eventHintText;

    [Header("Event Completetion Options")]
    public bool completesEventStep;
    public int completeEventID;
    public int step;

    //Private Variables
    private bool interactedWith = false;
    private bool interactionRemoved = false;
    private bool firstClick = true;


    //Determines type of trigger by using string
    //Trigger Types: enter, exit, and click
    public void Triggered(string trigger)
    {
        if (!interactionRemoved)
        {
            bool eventCheck = true;

            if (requiresEventCheck)
            {
                eventCheck = emailSystem.GetComponent<EventLog>().isComplete(eventIDRequired);
            }


            if (trigger == "enter")
            {
                Debug.Log("Interaction Enter");
                if (displayUIText && !displayAltUIText)
                    DisplayUIText();
                else
                {
                    if (eventCheck)
                        DisplayUIText();
                    else
                        DisplayAltUIText();
                }
                if (interactOnTouch && eventCheck && !interactedWith)
                {
                    if (createEmail)
                        CreateEmail();

                    if (creatEvent)
                        CreateEvent();

                    if (turnsOnLights)
                        Debug.Log("Lights On");
                        darkness.GetComponent<cameraShake>().lightOn = true;

                    if (turnsOffLights)
                        Debug.Log("Lights Off");
                        darkness.GetComponent<cameraShake>().lightOn = false;

                    if (cameraShake)
                        Debug.Log("Camera Shake");
                        darkness.GetComponent<cameraShake>().shake = true;

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

                if (displayObjectOnClick && firstClick)
                {
                    DisplayObject();
                    firstClick = false;
                } else if (displayObjectOnClick && !firstClick)
                {
                    RemoveObject();
                    firstClick = true;
                }

                if (removeObjectOnClick)
                {
                    RemoveObject();
                    interactionRemoved = true;
                    RemoveUIText();
                }
                if (removeInteractionOnClick)
                {
                    interactionRemoved = true;
                    RemoveUIText();
                }

            }

            if (repeatInteraction)
            {
                interactedWith = false;
            }
        }

    }

    //Displays Text on UI object 
    void DisplayUIText()
    {
        //need to implement UI Object to display
        Debug.Log(UIText);
        //interactionCanvas.GetComponent<InteractionCanvasController>().TurnOn(displayUIText);
    }

    void DisplayAltUIText()
    {
        //need to implement UI Object to display
        Debug.Log(UIText);
        //interactionCanvas.GetComponent<InteractionCanvasController>().TurnOn(displayUIText);
    }

    void RemoveUIText()
    {
        //interactionCanvas.GetComponent<InteractionCanvasController>().TurnOff();
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
