using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckPointCanvasController : MonoBehaviour
{

    public Text checkPointText;
    // Start is called before the first frame update

    public void newText(string text)
    {
        checkPointText.text += text + "\n";
    }
}
