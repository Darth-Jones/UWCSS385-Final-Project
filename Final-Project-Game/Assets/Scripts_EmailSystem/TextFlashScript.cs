using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextFlashScript : MonoBehaviour
{

    public float dur = 5f;
    private float startTime = 0f;
    private float currentTime = 0f;
    private bool flash = false;
    private string questText = "";

    [SerializeField]
    private Text text;
    // Start is called before the first frame update
    void Start()
    {
        text.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        currentTime = Time.time;
        if (flash)
        {
            text.text = questText;
        }
        else
        {

        }
        if (startTime != 0.0f)
        {
            if (currentTime - startTime > dur)
            {
                startTime = 0.0f;
                flash = false;
                text.text = "";
                gameObject.SetActive(false);
            }
        }

    }


    public void Flash(string text)
    {
        Debug.Log("FLASHING");
        

        //  StartCoroutine(ShowAndHide(text));
        this.gameObject.SetActive(true);
        gameObject.transform.GetChild(0).gameObject.SetActive(true);
        //    gameObject.GetComponentInChildren<>
        startTime = Time.time;
        flash = true;
        questText = text;
    }
}
