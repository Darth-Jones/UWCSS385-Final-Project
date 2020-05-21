using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITracking : MonoBehaviour
{

    // Counters 
    private int touched;
    private int egged;
    private int eggCount;


    private string[] mode = { "Mouse", "Keyboard" };
    private int modeIndex;

    private string[] path = { "Random", "Sequential" };
    private int pathIndex;
    // Start is called before the first frame update
    void Start()
    {
        touched = 0;
        egged = 0;
        eggCount = 0;
        modeIndex = 1;
        pathIndex = 1;
    }

    // Update is called once per frame
    void Update()
    {
        eggCount = GameObject.FindGameObjectsWithTag("Bullet").Length;
    }

    void OnGUI()
    {
     //   GUI.Label(new Rect(5, 0, 1000, 50), "WAYPOINTS: " + path[pathIndex] + " | ENEMIES: Touched: " + touched + " Egged: " + egged +
      //      " Total: " + (touched + egged) + " | EGG COUNT: " + eggCount + " | MODE: " + mode[modeIndex]);
    }


    // called when the hero touches an enemy
    public void newTouch()
    {
        touched++;
    }

    // called when an egg destroys an enemy
    public void PlaneKilledByEgg()
    {
        egged++;
    }

    // called when the M key is pressed
    public void ModeChange()
    {
        modeIndex = (modeIndex + 1) % 2;
    }

    public void PathChange()
    {
        pathIndex = (pathIndex + 1) % 2;
    }
}
