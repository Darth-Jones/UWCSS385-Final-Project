using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;
using System.Transactions;

public class EventLog : MonoBehaviour
{

    //public bool readchedA = false;

    public Stack checkPointText;
    private Dictionary<int, Event> eventList;

    public GameObject flashingText;
    public GameObject emailCanvas;
    public GameObject bodyCanvas;
    private bool showEmailCanvas;


    public int currentID = -1;
    private string a;
    // Start is called before the first frame update
    void Start()
    {
        showEmailCanvas = false;
        checkPointText = new Stack();
        checkPointText.Push("");
        eventList = new Dictionary<int, Event>();

    }



    // Update is called once per frame
        void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            showEmailCanvas = !showEmailCanvas;
            emailCanvas.SetActive(showEmailCanvas);
            bodyCanvas.SetActive(showEmailCanvas);        
        }
    }

    void OnGUI()
    {
        GUI.Label(new Rect(5, 0, 1000, 50), a);
    }

    public void newText(string text, int ID)
    {
        Debug.Log("ID: " + currentID + " questID: " + ID);
        if (ID > currentID)
        {
            a = text;
            currentID = ID;
        }
    }

    public void newEvent(int eventID)
    {
        eventList.Add(eventID, new Event(eventID));
    }

    public bool eventCompleted(int eventID)
    {
        return eventList[eventID].eventCompleted();
    }
    
}
