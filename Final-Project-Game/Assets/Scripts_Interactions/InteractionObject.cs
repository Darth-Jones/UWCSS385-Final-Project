﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractionObject : MonoBehaviour
{
    [Header("Object Connections")]
    public GameObject interactable;
    public GameObject emailSystem;

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

    [Header("Win Condition")]
    public bool winConditon = false;
    public string levelName;

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
    private GameObject interactionCanvas;
    private InteractableCanvas interactionText;

    private void Start()
    {
        emailSystem = GameObject.FindGameObjectWithTag("emailSystem");
        GameObject interactionCanvas = GameObject.FindGameObjectWithTag("interactionTextField");
        interactionText = interactionCanvas.GetComponent<InteractableCanvas>();
    }

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

                    if (winConditon)
                        SceneManager.LoadScene(levelName, LoadSceneMode.Single);

                    if (turnsOnLights)
                        darkness.GetComponent<cameraShake>().lightOn = true;

                    if (turnsOffLights)
                        darkness.GetComponent<cameraShake>().lightOn = false;

                    if (cameraShake)  
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
                    RemoveUIText();
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
        interactionText.TurnOnInteractibleCanvas(UIText);
    }

    void DisplayAltUIText()
    {
        //need to implement UI Object to display
        Debug.Log(UIAltText);
        interactionText.TurnOnInteractibleCanvas(UIAltText);
    }

    void RemoveUIText()
    {
        interactionText.TurnOffInteractibleCanvas();
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
