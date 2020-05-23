using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EmailButton : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Text headerText;

    public GameObject bodyCanvas;
    public GameObject eventLog;

    public Email email;
    public void SetEmail(Email newEmail)
    {
        Debug.Log(newEmail.headerText);
        email = newEmail;

        Debug.Log("creating email:" + newEmail.hintText);
        this.headerText.text = newEmail.headerText;
    }
    
    // Update is called once per frame
    public void OnClick()
    {
        Debug.Log("click worked");
        string hintText = email.OnClick();
        if (hintText != "")
        {
            eventLog.GetComponent<EventLog>().FlashText(hintText);
            eventLog.GetComponent<EventLog>().newHintText(hintText);
        }

        bodyCanvas.GetComponentInChildren<Text>().text = email.bodyText;
    }
}
