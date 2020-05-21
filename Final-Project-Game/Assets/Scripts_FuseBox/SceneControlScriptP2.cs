using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControlScriptP2 : MonoBehaviour
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
        if (CableScript.totalTile1 == 26 && CableScript.totalTile3 == 29
            && CableScript.totalTile2 == 32) {
            unlockText.SetActive(true);
            Invoke("NextScene", 3);
        }
    }

    void NextScene() {
        SceneManager.LoadScene(nextScene);
    }
}
