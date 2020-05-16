using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ForwardScript : MonoBehaviour
{
    public string sceneName;

    public void Forward() {
        SceneManager.LoadScene(sceneName);
    }
}
