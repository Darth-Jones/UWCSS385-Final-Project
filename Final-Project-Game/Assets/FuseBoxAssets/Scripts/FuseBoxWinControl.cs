using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FuseBoxWinControl : MonoBehaviour
{
    public GameObject emailSystem;
    public string[] hintText = { "Item transfer system beeped: it's now up and running" };
    public int eventID;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (CableScript.totalTile1 == CableScript.numberNeeded1 &&
            CableScript.totalTile2 == CableScript.numberNeeded2
            && CableScript.totalTile3 == CableScript.numberNeeded3)
        {
            // create an even
            // check the event
            // unlocks the transfer system

            emailSystem.GetComponent<EventLog>().CreateEvent(eventID, 1, hintText); //using event 10
            emailSystem.GetComponent<EventLog>().StepCompleted(eventID, 0);
            Debug.Log("SOLVED");
        }
    }

}
