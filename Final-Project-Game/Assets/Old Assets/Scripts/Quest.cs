using System.Numerics;
using System.Collections;
using System.IO;
using UnityEngine;

public abstract class Quest
{

    public int questID;
    public bool questFinished;
    public ArrayList questSteps;
    public GameObject questTracker;

    public Quest()
    {

    }
    public Quest(int questID)
    {
        string path = Application.dataPath + "questObj" + questID + ".txt";
        string questText = File.ReadAllText(path);
        questTracker = GameObject.Find("EventTracker");
        questFinished = false;
    }

    public string getNextStep()
    {
        return (string)questSteps[0];
    }


    public abstract bool stepCompleted(int stepNumber);



    
}