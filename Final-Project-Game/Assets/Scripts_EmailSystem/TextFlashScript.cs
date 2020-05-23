using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextFlashScript : MonoBehaviour
{

    private float dur = 2f;
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
       // gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        currentTime = Time.time;
        if (flash)
        {
            text.text = questText;
            //enabled = true;
          //  gameObject.SetActive(true);
            //  <Text>().text = questText;
            //  gameObject.GetComponent<Text>() = true;
            // SpriteRenderer sprite = gameObject.GetComponent<SpriteRenderer>();
            //  sprite.color = new Color(1f, 1f, 1f, 1f);

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
               // gameObject.transform.GetChild(0).gameObject.SetActive(true);
                // enabled = false;
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
