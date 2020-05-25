using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuEmailButton : MonoBehaviour
{
    public GameObject checkPointCanvas;
    public GameObject emailCanvas;
    // Start is called before the first frame update
    public void OnClick()
    {
        checkPointCanvas.SetActive(false);
        emailCanvas.SetActive(true);
    }
}
