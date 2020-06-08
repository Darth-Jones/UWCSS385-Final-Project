using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{

    public bool enabled = true;
    public int[,] keyCode;
    public string[] numberStrings;
    public int numNumberStrings = 1;

    public char[] numChars;
    // Start is called before the first frame update
    void Start()
    {
        keyCode = new int[numNumberStrings,numberStrings[0].Length];
        int j = 0;
        foreach (string nums in numberStrings) {
            
            numChars = nums.ToCharArray(0,nums.Length);
            
            
            int i = 0;
            foreach(char num in numChars) {
                keyCode[j, i] = num - 48;
                Debug.Log("Keycode" + i + " = " + keyCode[j, i] );
                i++;
            }
            j++;
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
