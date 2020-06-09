using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodTypeSequenceScript : MonoBehaviour
{
    public FinalPuzzleWinControl winControl;

    public int value;
  
    public void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0)) {

            winControl.GetComponent<FinalPuzzleWinControl>().AddToWinSequence(value);
        }
    }

}
