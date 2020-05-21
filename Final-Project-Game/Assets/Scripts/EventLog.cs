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
    private Dictionary<int, Quest> questList;
    public Dictionary<int, bool> questBool;

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
        questList = new Dictionary<int, Quest>();
        questBool = new Dictionary<int, bool>();

       // questList.Add(0, new EmailQuest(0));
    //    questList.Add(1, new EmailQuest(1));
        // questText.Add(0, "Reached the A marker");
        // questBool.Add(0, false);
        /*
  
        questText.Add(1, "Reached the D marker");
        questBool.Add(1, false);

        questText.Add(2, "Reached the B marker");
        questBool.Add(2, false);

        questText.Add(3, "Reached the C marker");
        questBool.Add(3, false);
        */
    }



    // Update is called once per frame
        void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {

            showEmailCanvas = !showEmailCanvas;
            emailCanvas.SetActive(showEmailCanvas);
            bodyCanvas.SetActive(showEmailCanvas);
            
            //    uiCounter.GetComponent<UITracking>().ModeChange();
            //    mouseControl = !mouseControl;
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

    public void newEvent(int eventID, int stepID)
    {
        questList[eventID].stepCompleted(stepID);
        a = (string)checkPointText.Peek();
        /*
        if (questBool[eventID] == false)
        {
            if (eventID < 3)
            {
                // flashingText.Test();
                questBool[eventID] = true;
                flashingText.GetComponent<TextFlashScript>().Flash(questText[eventID]);
            }
            else 
            {
                if (questBool[0] && questBool[1] && questBool[2])
                {
                    questBool[eventID] = true;
                    flashingText.GetComponent<TextFlashScript>().Flash(questText[eventID]);
                }
            }
        }
        */
    }
    
}
