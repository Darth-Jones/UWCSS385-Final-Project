using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{

    public bool enabled = true;
    public int[] keyCode;
    public string numbers = "0000000";
    public int firstNum;
    public int secondNum;
    public int thirdNum;
    public int fourthNum;
    public int fifthNum;
    public int sixthNum;
    public int seventhNum;

    public char[] numChars;
    // Start is called before the first frame update
    void Start()
    {
        numChars = numbers.ToCharArray(0,numbers.Length);
        int i = 0;
        keyCode = new int[numbers.Length];
        foreach(char num in numChars) {
            keyCode[i] = num - 48;
            Debug.Log("Keycode" + i + " = " + keyCode[i] );
            i++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(!enabled) {
            this.gameObject.SetActive(false);
        }
    }
}
