﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cameraShake : MonoBehaviour
{
    // Start is called before the first frame update
    // Shakes the camera and Turns out the lights
    
    public GameObject cameraObject;
    public float shakeLength;
    public float shakeSize;
    public Vector3 cameraOrigPos;
    private cameraFollowScript2 cameraScript;
    Rigidbody2D rb2d;
    public bool shake = false;
    private bool lastShake = false;
    private float i;
    private float j;
    private int frameCounter;
    private int startShake;
    private float endShake;
    public GameObject darkUI;
    private RawImage image;
    public Color c;
    public int startMaze = 1;
    public int endMaze = 52;
    private bool shook = false;
    private RectTransform UIsize; 
    public bool visible = true;
    public bool lightOn = true;


    // Start is called before the first frame update


    void Start()
    {
        cameraObject = GameObject.FindGameObjectsWithTag("MainCamera")[0];
        cameraScript = cameraObject.GetComponent<cameraFollowScript2>();
        darkUI = GameObject.FindGameObjectsWithTag("darkUI")[0];
        image = darkUI.GetComponent<RawImage>();
        UIsize = darkUI.GetComponent<RectTransform>();
        i = 0;
        j = 30;
        frameCounter = 0;
        c = image.color;
        c.a = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (lightOn) lighten();
        else darken();
        cameraOrigPos = cameraScript.expectedPos;

        frameCounter++;
        if(shake) {
            startShake = frameCounter;
            i = 0;
            j = 60;
            
            endShake = startShake + 120 + shakeLength * 60;
            shake = false;
        }
        if (frameCounter < endShake && startShake < frameCounter) {
            i++;
                if ( i < 60) {
                    
                    float xMovement = Random.Range(-shakeSize * i/60, shakeSize * i/60);
                    float yMovement = Random.Range(-shakeSize * i/60, shakeSize * i/60);
                    cameraObject.transform.position = cameraOrigPos + new Vector3(xMovement, yMovement, -10);
                }
                else if ( i > 60 && i < shakeLength * 60 + 60) {
                    float xMovement = Random.Range(-shakeSize, shakeSize);
                    float yMovement = Random.Range(-shakeSize, shakeSize);
                    cameraObject.transform.position = cameraOrigPos + new Vector3(xMovement, yMovement, -10);
                }
                else {
                    float xMovement = Random.Range(-shakeSize * j/60, shakeSize * j/60);
                    float yMovement = Random.Range(-shakeSize * j/60, shakeSize * j/60);
                    cameraObject.transform.position = cameraOrigPos + new Vector3(xMovement, yMovement, -10);
                    j--;
                    
                }
            
            
        }

        //Debug.Log("StartShake = " + startShake + " EndShake = " + endShake + " frameCounter = " + frameCounter + " i = " + i + " j = " + j);
        
    }

    public void lighten() {
        //Debug.Log(" LOCAL SCALE: " +UIsize.localScale);
        if (UIsize.localScale.x < 15) {
            Vector3 currentScale = UIsize.localScale;
            currentScale = new Vector3(currentScale.x += .05f, currentScale.y += .05f, 1);
            UIsize.localScale = currentScale;
            Debug.Log(UIsize.localScale);
        }
    }

    public void darken() {
        if (UIsize.localScale.x > 5) {
            Vector3 currentScale = UIsize.localScale;
            currentScale = new Vector3(currentScale.x -= .05f, currentScale.y -= .05f, 1);
            UIsize.localScale = currentScale;
        }
    }

}
