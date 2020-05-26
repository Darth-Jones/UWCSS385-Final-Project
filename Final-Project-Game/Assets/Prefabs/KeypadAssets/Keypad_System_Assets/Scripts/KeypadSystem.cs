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

    // Start is called before the first frame update
    void Start()
    {
        numbers = new int[maxNumbers];
        displayNumbers = new List<GameObject>(GameObject.FindGameObjectsWithTag("DisplayNumber"));
        sortedDisplayNumbers = displayNumbers.OrderBy(displayNumber => displayNumber.transform.position.x).ToList();
        numberToDisplay = new SpriteRenderer[maxNumbers];
        numSprites =  Resources.LoadAll<Sprite>("Keypad_System_Assets/Display_Numbers");
        for(int i = 0; i < sortedDisplayNumbers.Count; i++ ) {
            numberToDisplay[i] = sortedDisplayNumbers[i].GetComponent<SpriteRenderer>();
            Debug.Log(numberToDisplay[i]);
            //Debug.Log(numSprites[i]);
            //Debug.Log(numbers.Length);
            
        }
        numSprites =  Resources.LoadAll<Sprite>("Keypad_System_Assets/Display_Numbers");
        doorScript = door.GetComponent<DoorScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
            UpdateKeyPadDisplay();
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
        if(doorScript != null) {
            if (numbers == doorScript.keyCode) doorScript.enabled = false;
        }

        //if (numbers == trigger.expectedNums) {
            //  Perform Trigger
        //}
    }
}
