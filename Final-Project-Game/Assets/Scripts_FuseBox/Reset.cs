using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reset : MonoBehaviour
{
    public string sceneName;

    // Method to reset a scene
    public void ResetPuzzle()
    {
        SceneManager.LoadScene(sceneName);
        CableScript.ResetVariables();

    }
}
