﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackScript : MonoBehaviour
{
    public string sceneName;

    public void Back() {
        SceneManager.LoadScene(sceneName);
    }
}
