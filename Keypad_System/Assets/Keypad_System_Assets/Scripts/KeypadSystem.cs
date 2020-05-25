using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeypadSystem : MonoBehaviour
{
    public int maxNumbers = 7; //The count of input numbers
    private int[] numbers;
    private int numberLocation = 0;

    // Start is called before the first frame update
    void Start()
    {
        numbers = new int[maxNumbers];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
            UpdateKeyPadDisplay();
    }

    public void ProcessNumberPress(int inputNumber)
    {
        if(numbers.Length < maxNumbers)
        {
            numbers[numberLocation] = inputNumber;
            numberLocation++;
        }
        UpdateKeyPadDisplay();
    }

    void UpdateKeyPadDisplay()
    {
        SpriteRenderer displayNumber = this.transform.GetChild(0).GetComponent<SpriteRenderer>();    
        displayNumber.enabled = !displayNumber.enabled;
    }

    void ClearKeyPadDisplay()
    {

    }

    void EnterKeyPressed()
    {

    }
}
