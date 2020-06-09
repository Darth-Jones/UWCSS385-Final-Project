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
    private int[] winningSequence1 = new int[] { 0, 8, 16 };
    private int[] winningSequence2 = new int[] { 0, 16, 8 };
    private int[] winningSequence3 = new int[] { 16, 8, 0 };
    private int[] winningSequence4 = new int[] { 16, 0, 8 };
    private int[] winningSequence5 = new int[] { 8, 0, 16 };
    private int[] winningSequence6 = new int[] { 8, 16, 0 };

    private List<int> enteredSequence;
    public SpriteRenderer sr;
    public Sprite errorFlash;
    public GameObject errorMessage;
    public ButtonSelected buttonSelected;



  
    // Start is called before the first frame update
    void Start()
    {
        enteredSequence = new List<int>();
        errorMessage.SetActive(false);
    }

    public void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0)) {

            if (!called)

            {
                if (winningSequence1.SequenceEqual(enteredSequence) ||
                    winningSequence2.SequenceEqual(enteredSequence) ||
                    winningSequence3.SequenceEqual(enteredSequence) ||
                    winningSequence4.SequenceEqual(enteredSequence) ||
                    winningSequence5.SequenceEqual(enteredSequence) ||
                    winningSequence6.SequenceEqual(enteredSequence))
                {
                    Debug.Log("SOLVED");
                    //called = true;
                    //emailSystem.GetComponent<EventLog>().CreateEvent(eventID, 1, hintText); //using event 10
                    //emailSystem.GetComponent<EventLog>().StepCompleted(eventID, 0);
                }
                else {
                    Debug.Log("Not Solved");
                    errorMessage.SetActive(true);
                    Invoke("HideErrorMessage", 2);
                    buttonSelected.GetComponent<ButtonSelected>().OnSubmit();
                }
                enteredSequence = new List<int>();
            }
        }
    }

    private void HideErrorMessage() {
        errorMessage.SetActive(false);
    }

    public void AddToWinSequence(int numToAdd) {
        enteredSequence.Add(numToAdd);
    }
}
