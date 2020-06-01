using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{

    public bool enabled = true;
    public int[] keyCode;
    public int firstNum;
    public int secondNum;
    public int thirdNum;
    public int fourthNum;
    public int fifthNum;
    public int sixthNum;
    public int seventhNum;
    // Start is called before the first frame update
    void Start()
    {
        keyCode = new int[] {firstNum, secondNum, thirdNum, fourthNum, fifthNum, sixthNum, seventhNum};
    }

    // Update is called once per frame
    void Update()
    {
        if(!enabled) {
            this.gameObject.SetActive(false);
        }
    }
}
