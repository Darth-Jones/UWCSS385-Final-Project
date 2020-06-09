using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FinalPuzzleWinControl : MonoBehaviour
{
    public GameObject emailSystem;
    public string[] hintText = { "Item transfer system beeped: it's now up and running" };
    public int eventID;
    private bool called = false;
    private int[] winningSequence = new int[] { 0, 8, 16 };
    private List<int> enteredSequence;

  
    // Start is called before the first frame update
    void Start()
    {
        enteredSequence = new List<int>();
    }

    public void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0)) {

            if (!called)

            {
                if (winningSequence.SequenceEqual(enteredSequence))
                {
                    Debug.Log("SOLVED");
                    //called = true;
                    //emailSystem.GetComponent<EventLog>().CreateEvent(eventID, 1, hintText); //using event 10
                    //emailSystem.GetComponent<EventLog>().StepCompleted(eventID, 0);
                }
                else {
                    Debug.Log("Not Solved");
                    enteredSequence = new List<int>();
                }
            }
        }
    }

    public void AddToWinSequence(int numToAdd) {
        enteredSequence.Add(numToAdd);
    }
}
