using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button_Change_Scene : MonoBehaviour
{
	public string levelName;

    void OnMouseOver()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("Loading Scene: " + levelName);
            SceneManager.LoadScene(levelName, LoadSceneMode.Single);
        }
    }
        
	
}
