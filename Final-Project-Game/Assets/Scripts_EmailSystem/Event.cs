﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event
{
    int eventID;
    int stepCount;
    bool[] questSteps;
    string[] hintText;
    bool completed;

    public Event(int eventID)
    {
        this.eventID = eventID;
        this.stepCount = 1;
        this.questSteps = new bool[1];
        this.completed = false;
    }

    public Event(int eventID, int stepCount, string[] hintText)
    {
        this.eventID = eventID;
        this.stepCount = stepCount;
        this.questSteps = new bool[stepCount];
        this.hintText = new string[stepCount];
        this.completed = false;

        for (int i = 0; i < stepCount; i++)
        {
            this.hintText[i] = hintText[i];
        }
    }
    
    public string stepCompleted(int stepID)
    {
        questSteps[stepID] = true;

        for (int i = 0; i < stepCount; i++)
        {
            if (!questSteps[i])
            {
                return hintText[stepID];
            }
        }

        completed = true;
        return hintText[stepID];
    }

    public bool isComplete()
    {
        return completed;
    }
}
