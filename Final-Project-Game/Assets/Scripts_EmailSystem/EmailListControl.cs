using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class EmailListControl : MonoBehaviour
{

    [SerializeField]
    private GameObject buttonTemplate;

    public GameObject flashingText;

    public GameObject eventLog;

    private int startingEmailCount = 6;
    // Start is called before the first frame update

    private List<GameObject> buttonList;

    private void Start()
    {
        //  emailList = new List<Email>();
        GenStartingEmails();
    }

    private void GenStartingEmails()
    {
        string path = Application.dataPath + "/Text/startingEmails.txt";
        Debug.Log(path);
        string questText = File.ReadAllText(path);
        string[] emailTextSplit = questText.Split('|');


        Debug.Log("first button" + emailTextSplit[1]);

        GameObject button = Instantiate(buttonTemplate) as GameObject;
        button.SetActive(true);

        button.GetComponent<EmailButton>().SetEmail(new Email(0, emailTextSplit[0], emailTextSplit[1]));
        button.transform.SetParent(buttonTemplate.transform.parent, false);


        Debug.Log("2nds button");

        GameObject button2 = Instantiate(buttonTemplate) as GameObject;
        button2.SetActive(true);

        button2.GetComponent<EmailButton>().SetEmail(new Email(1, emailTextSplit[2], emailTextSplit[3], "the email mentioned the A waypoint..."));
        button2.transform.SetParent(buttonTemplate.transform.parent, false);

        Debug.Log("thirds button");


        GameObject button3 = Instantiate(buttonTemplate) as GameObject;
        button3.SetActive(true);

        button3.GetComponent<EmailButton>().SetEmail(new Email(2, emailTextSplit[4], emailTextSplit[5]));
        button3.transform.SetParent(buttonTemplate.transform.parent, false);
    }








    public void CreateEmail(int emailID)
    {
    //    eventLog.GetComponent<EventLog>().FlashText("New Email");

        flashingText.GetComponent<TextFlashScript>().Flash("NEW EMAIL");

        GameObject button = Instantiate(buttonTemplate) as GameObject;
        button.SetActive(true);

        button.GetComponent<EmailButton>().SetEmail(new Email(emailID));
        button.transform.SetParent(buttonTemplate.transform.parent, false);
    }

    public void CreateEmail(int emailID, string headerText, string bodyText)
    {
        eventLog.GetComponent<EventLog>().FlashText("New Email");
        GameObject button = Instantiate(buttonTemplate) as GameObject;
        button.SetActive(true);

        button.GetComponent<EmailButton>().SetEmail(new Email(emailID, headerText, bodyText));
        button.transform.SetParent(buttonTemplate.transform.parent, false);
    }

    public void CreateEmail(int emailID, string headerText, string bodyText, string hintText)
    {
        eventLog.GetComponent<EventLog>().FlashText("New Email");
        GameObject button = Instantiate(buttonTemplate) as GameObject;
        button.SetActive(true);

        button.GetComponent<EmailButton>().SetEmail(new Email(emailID, headerText, bodyText, hintText));
        button.transform.SetParent(buttonTemplate.transform.parent, false);
    }
}
