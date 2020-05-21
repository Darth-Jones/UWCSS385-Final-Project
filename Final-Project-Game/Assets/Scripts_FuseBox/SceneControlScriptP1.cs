using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControlScriptP1 : MonoBehaviour
{
    [SerializeField]
    public GameObject unlockText;
    public string nextScene;

    // Start is called before the first frame update
    void Start()
    {
        unlockText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (CableScript.totalTile1 == 35 && CableScript.totalTile2 == 23
            && CableScript.totalTile3 == 27)
        {
            unlockText.SetActive(true);
            Invoke("NextScene", 3);
        }
    }

    void NextScene()
    {
        SceneManager.LoadScene(nextScene);
    }
}
