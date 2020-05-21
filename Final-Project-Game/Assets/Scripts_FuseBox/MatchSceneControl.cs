using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MatchSceneControl : MonoBehaviour
{
    [SerializeField]
    public GameObject winText;

    private InputField input1;
    private InputField input2;
    private InputField input3;
    private InputField input4;
    private InputField input5;
    private InputField input6;
    private InputField input7;
    private InputField input8;
    private InputField input9;
    private InputField input10;

    private void Awake()
    {
        input1 = GameObject.Find("Tile1").GetComponent<InputField>();
        input2 = GameObject.Find("Tile2").GetComponent<InputField>();
        input3 = GameObject.Find("Tile3").GetComponent<InputField>();
        input4 = GameObject.Find("Tile4").GetComponent<InputField>();
        input5 = GameObject.Find("Tile5").GetComponent<InputField>();
        input6 = GameObject.Find("Tile6").GetComponent<InputField>();
        input7 = GameObject.Find("Tile7").GetComponent<InputField>();
        input8 = GameObject.Find("Tile8").GetComponent<InputField>();
        input9 = GameObject.Find("Tile9").GetComponent<InputField>();
        input10 = GameObject.Find("Tile10").GetComponent<InputField>();
    }
    // Start is called before the first frame update
    void Start()
    {
        winText.SetActive(false);
        //tile1 = GameObject.FindGameObjectWithTag("Tile1");
    }

    //public void GetInput(string number) {

    //}

    // Update is called once per frame
    void Update()
    {
        if (input1.text == "13" && input2.text == "17"
            && input3.text == "16" && input4.text == "9"
            && input5.text == "26" && input6.text == "15"
            && input7.text == "12" && input8.text == "32"
            && input9.text == "19" && input10.text == "5")
        {
            winText.SetActive(true);
        }
    }
}
