using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event
{
    int eventID;
    int stepCount;
    bool[] questSteps;
    bool completed;

    public Event(int eventID)
    {
        this.eventID = eventID;
        this.stepCount = 1;
        this.questSteps = new bool[1];
        this.completed = false;
    }

    public Event(int eventID, int stepCount)
    {
        this.eventID = eventID;
        this.stepCount = stepCount;
        this.questSteps = new bool[stepCount];
        this.completed = false;
    }
    
    public bool stepCompleted(int stepID)
    {
        questSteps[stepID] = true;
        for (int i = 0; i < stepCount; i++)
        {
            if (!questSteps[i])
            {
                return false;
            }
        }

        completed = true;
        return completed;
    }

    public bool eventCompleted()
    {
        return completed;
    }
}
