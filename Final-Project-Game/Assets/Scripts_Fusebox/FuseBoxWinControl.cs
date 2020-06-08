using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FuseBoxWinControl : MonoBehaviour
{
    public GameObject emailSystem;
    public string[] hintText = { "Item transfer system beeped: it's now up and running" };
    public int eventID;
    private bool called = false;
    public GameObject camera;
    private Transform cameraTransform;
    // Start is called before the first frame update
    void Start()
    {
        cameraTransform = camera.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {

        //transform.position = new Vector3(cameraTransform.position.x - 2, cameraTransform.position.y + 2, 0);
        if (!called) {
            
            if (CableScript.totalTile1 == CableScript.numberNeeded1 &&
                CableScript.totalTile2 == CableScript.numberNeeded2
                && CableScript.totalTile3 == CableScript.numberNeeded3)
            {
                // create an even
                // check the event
                // unlocks the transfer system
                Debug.Log("SOLVED");
                called = true;
                emailSystem.GetComponent<EventLog>().CreateEvent(eventID, 1, hintText); //using event 10
                emailSystem.GetComponent<EventLog>().StepCompleted(eventID, 0);
            }
        }
    }
}
