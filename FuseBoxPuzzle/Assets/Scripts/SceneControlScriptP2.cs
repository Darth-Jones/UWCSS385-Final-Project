using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneControlScriptP2 : MonoBehaviour
{
    [SerializeField]
    public GameObject unlockText;

    // Start is called before the first frame update
    void Start()
    {
        unlockText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(CableScript.totalTile1 + ", " + CableScript.totalTile2 + ", " + CableScript.totalTile3);
        if (CableScript.totalTile1 == 26 && CableScript.totalTile3 == 29
            && CableScript.totalTile2 == 32) {
            unlockText.SetActive(true);
        }
    }
}
