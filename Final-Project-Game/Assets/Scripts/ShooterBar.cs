using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterBar : MonoBehaviour
{
    private float barSize;
    private GameObject Launcher;
    private EggLauncher eComp;
    private Renderer rend;
    private GameObject theBar;
    private RectTransform theBarRectTransform;


    // JAMES CHANGED THIS AND PUSHED!!!

    // Start is called before the first frame update
    void Start()
    {
        //Finds the eggLauncher gameObject
        Launcher = GameObject.FindGameObjectWithTag("Shooter");

        //Finds the eggLauncher Component Script
        eComp = Launcher.GetComponent<EggLauncher>();

        //Finds the Shooterbar UI Object
        theBar = GameObject.Find("Canvas/ShooterBar");

        //Find the ShooterBar transform
        theBarRectTransform = theBar.transform as RectTransform;

    }

    private void FixedUpdate()
    {
        
        
        // Uses the same key and timer mechanism to control scale of UI bar
        if (Input.GetKey(eComp.keyToPress)
            || Time.time <= eComp.timeOfLastSpawn + eComp.creationRate)
        {
            Debug.Log("Shooter Bar Activation");
            float scaleFactor = (Time.time - eComp.timeOfLastSpawn) / eComp.creationRate;
            barSize = 200 - (200 * scaleFactor);
            theBarRectTransform.sizeDelta = new Vector2(barSize, 20);

        }
        else
        {
            //When not in use ShooterBar Scale set to 0
            theBarRectTransform.sizeDelta = new Vector2(0, 0);
        }
    }
}
//