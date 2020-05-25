using System.Collections;
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
    private RectTransform size; 
    public GameObject[] waypoints;
    public bool visible = true;

    // Start is called before the first frame update


    void Start()
    {
        cameraObject = GameObject.FindGameObjectsWithTag("MainCamera")[0];
        cameraScript = cameraObject.GetComponent<cameraFollowScript2>();
        darkUI = GameObject.FindGameObjectsWithTag("darkUI")[0];
        image = darkUI.GetComponent<RawImage>();
        size = darkUI.GetComponent<RectTransform>();
        i = 0;
        j = 30;
        frameCounter = 0;
        c = image.color;
        c.a = 0;
        waypoints = GameObject.FindGameObjectsWithTag("Waypoint");
    }

    // Update is called once per frame
    void Update()
    {

        // Testing purposes
        if (Input.GetKeyDown(KeyCode.Z)) {
            size.localScale = size.localScale * 2;
        }
        if (Input.GetKeyDown(KeyCode.X)) {
            size.localScale = size.localScale * .5f;
        }
        if (Input.GetKeyDown(KeyCode.H)) {
            if (visible) {
                foreach (GameObject waypoint in waypoints)
                {
                    Renderer r = waypoint.GetComponent<Renderer>();
                    Color newColor = r.material.color;
                    newColor.a = 0;
                    r.material.color = newColor;
                    visible = false;
                }
            }
            else {
                foreach (GameObject waypoint in waypoints)
                {
                    Renderer r = waypoint.GetComponent<Renderer>();
                    Color newColor = r.material.color;
                    newColor.a = 1;
                    r.material.color = newColor;
                    visible = true;
                }
            }
        }
        


        if (cameraOrigPos.x > startMaze + 10) { shake = false;}
        cameraOrigPos = cameraScript.expectedPos;
        frameCounter++;
        if(shake) {
            startShake = frameCounter;
            i = 0;
            j = 60;
            
            endShake = startShake + 120 + shakeLength * 60;
        }
        if (frameCounter < endShake && startShake < frameCounter) {
            i++;
            if (c.a < 1) {c.a = c.a + .005f;}
            image.color =  c;
            cameraScript.rubberBandNess = 1.5f;
            if (!shook) {
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
                if (frameCounter == endShake - 1) shook = true;
            }
            
        }
        if (cameraOrigPos.x < startMaze || cameraOrigPos.x > endMaze) {
            shake = true;
            if (c.a > 0) { c.a -= .005f; }
            image.color = c;
        }
        Debug.Log("StartShake = " + startShake + " EndShake = " + endShake + " frameCounter = " + frameCounter + " i = " + i + " j = " + j);
        
        //lastShake = shake;

        
        
    }


}
