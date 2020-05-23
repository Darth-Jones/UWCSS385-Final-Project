using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCheckpointButton : MonoBehaviour
{
    public GameObject checkPointCanvas;
    public GameObject emailCanvas;
    // Start is called before the first frame update
    public void OnClick()
    {
        emailCanvas.SetActive(false);
        checkPointCanvas.SetActive(true);
    }
}
