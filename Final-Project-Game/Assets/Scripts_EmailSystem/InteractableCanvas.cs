using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractableCanvas : MonoBehaviour
{

    public GameObject interactibleCanvas;
    public Text interactibleText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TurnOnInteractibleCanvas(string newText)
    {
        Debug.Log("newText: " + newText);
        interactibleCanvas.SetActive(true);
        
        interactibleText.text = newText;
        
    }
    public void TurnOffInteractibleCanvas()
    {
        Debug.Log("Turning off canvas");
        interactibleCanvas.SetActive(false);
    }

}
