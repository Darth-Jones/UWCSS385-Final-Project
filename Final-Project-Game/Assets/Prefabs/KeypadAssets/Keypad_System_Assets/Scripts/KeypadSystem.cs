using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class KeypadSystem : MonoBehaviour
{
    public int maxNumbers = 7; //The count of input numbers
    private int[] numbers; // actual numbers in array
    private int numberLocation = 0; //curent location in array
    private List<GameObject> displayNumbers; //objects for the number displays
    private SpriteRenderer[] numberToDisplay; //spriterenderers for display
    private List<GameObject> sortedDisplayNumbers; // sorted list of displays
    private Sprite[] numSprites; // array of sprites to grab from
    private bool lastReached = false; // keeps track of if max was reached
    public GameObject door;
    public DoorScript doorScript;
    public GameObject camera;
    public Transform cameraTransform;
    public bool transfer;
    public GameObject interactionObject;
    public InteractionObject interactionObjectScript;
    public int itemGatheredEventID;
    public int itemGatheredEmailID;
    public string itemGatheredEmailHeader;
    public string itemGatheredEmailBody;
    public string itemGatheredEmailHint;
    public int receivedEventID;
    public int receivedEmailID;
    public string receivedEmailHeader;
    public string receivedEmailBody;
    public string[] receivedEventHints;
    public string receivedEmailHint;
    public GameObject[] incorrect;

    // Start is called before the first frame update
    void Start()
    {
        numbers = new int[maxNumbers];
        displayNumbers = new List<GameObject>(GameObject.FindGameObjectsWithTag("DisplayNumber"));
        sortedDisplayNumbers = displayNumbers.OrderBy(displayNumber => displayNumber.transform.position.x).ToList();
        numberToDisplay = new SpriteRenderer[maxNumbers];
        numSprites =  Resources.LoadAll<Sprite>("/Prefabs/Keypad_System_Assets/Display_Numbers");
        for(int i = 0; i < sortedDisplayNumbers.Count; i++ ) {
            numberToDisplay[i] = sortedDisplayNumbers[i].GetComponent<SpriteRenderer>();
            Debug.Log(numberToDisplay[i]);
            //Debug.Log(numSprites[i]);
            //Debug.Log(numbers.Length);
            
        }
        numSprites =  Resources.LoadAll<Sprite>("Keypad_System_Assets/Display_Numbers");
        doorScript = door.GetComponent<DoorScript>();
        cameraTransform = camera.GetComponent<Transform>();
        if (transfer)
        {
            interactionObjectScript = interactionObject.GetComponent<InteractionObject>();
        }  
        incorrect = GameObject.FindGameObjectsWithTag("incorrect");

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
            UpdateKeyPadDisplay();
        transform.position = new Vector3(cameraTransform.position.x, cameraTransform.position.y, 0);
    }

    //Adds a number press to the Keypad
    public void ProcessNumberPress(int inputNumber)
    {
        
        if (!lastReached) {
            if(numbers.Length <= maxNumbers)
            {
                
                if ((numberLocation == maxNumbers )) {
                    lastReached = true;
                }
                else {
                    numbers[numberLocation] = inputNumber;
                }
                if (numberLocation < maxNumbers ) {
                    numberLocation++;
                    
                } 
            }
            UpdateKeyPadDisplay();
        }
    }
    

    //updates the sprites to display
    void UpdateKeyPadDisplay()
    {
        //Updates all the numbers with the sprites
        int i = 0;
        foreach (int number in numbers) {
            numberToDisplay[i].sprite = numSprites[number];
            i++;
            Debug.Log(number);
            lastReached = false;
        }
    }

    // Clears the display
    public void ClearKeyPadDisplay()
    {
        numbers = new int[maxNumbers];
        numberLocation = 0;
        UpdateKeyPadDisplay();
        //Debug.Log(numbers);
    }

    //processes the number and checks if correct
    public void EnterKeyPressed()
    {
        if(transfer) {
            if(interactionObjectScript.emailSystem.GetComponent<EventLog>().isComplete(itemGatheredEventID)) {

                //interactionObjectScript.emailSystem.GetComponent<EventLog>().CreateEvent();
                //interactionObjectScript.emailSystem.GetComponent<EventLog>().CompleteEvent();
                //interactionObjectScript.emailSystem.GetComponent<EventLog>().StepCompleted(receivedEventID, step);
                interactionObjectScript.emailSystem.GetComponent<EventLog>().CreateEmail(itemGatheredEmailID, itemGatheredEmailHeader, itemGatheredEmailBody, itemGatheredEmailHint);
            }
            else {
                numbers = new int[maxNumbers];
                numberLocation = 0;
                for(int i = 0; i < maxNumbers; i++) {
                    numberToDisplay[i].sprite = numSprites[11];
                }
                numberToDisplay[maxNumbers/2].sprite = numSprites[10];
                Debug.Log("Incorrect");
            }
        }
        else{
            bool correct = true;
            if(doorScript != null) {
                for( int i = 0; i < maxNumbers; i++) {
                    if (numbers[i] == null) {
                        correct = false;
                        break;
                    }
                    if (numbers[i] != doorScript.keyCode[0, i]) {
                        correct = false;
                        break;
                    }
                    i++;
                }
                if (correct) {
                        doorScript.enabled = false;
                
                        Debug.Log("Opened");
                        this.gameObject.SetActive(false);
                }
                else {
                    numbers = new int[maxNumbers];
                    numberLocation = 0;
                    for(int i = 0; i < maxNumbers; i++) {
                        numberToDisplay[i].sprite = numSprites[11];
                    }
                    numberToDisplay[maxNumbers/2].sprite = numSprites[10];
                    Debug.Log("Incorrect");
                }
            }
        }
    }

        //if (numbers == trigger.expectedNums) {
            //  Perform Trigger
        //}
    
    public void ReceiveKeyPressed() 
    {
        
        if(doorScript != null) {
            Debug.Log("Running");
            int i = 0;
            bool correct = true;
            Debug.Log("Outer loop");
            foreach(int number in numbers) {
                if (number != doorScript.keyCode[0, i]) {
                    correct = false;
                }
                i++;
            }
            if (correct) {
                
                interactionObjectScript.emailSystem.GetComponent<EventLog>().CreateEvent(receivedEventID, 1, receivedEventHints);
                interactionObjectScript.emailSystem.GetComponent<EventLog>().CreateEmail(receivedEmailID, receivedEmailHeader, receivedEmailBody, receivedEmailHint);
                interactionObjectScript.emailSystem.GetComponent<EventLog>().StepCompleted(receivedEventID, 0);
                //Perform step in interaction
            }
            if (!correct) {
                numbers = new int[maxNumbers];
                numberLocation = 0;
                for(int j = 0; j < maxNumbers; j++) {
                    numberToDisplay[j].sprite = numSprites[11];
                }
                numberToDisplay[maxNumbers/2].sprite = numSprites[10];
                Debug.Log("Incorrect");
            }
        }
    }
}
