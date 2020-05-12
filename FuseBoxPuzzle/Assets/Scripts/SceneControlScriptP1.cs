using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneControlScriptP1 : MonoBehaviour
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
        if (CableScript.totalTile1 == 35 && CableScript.totalTile2 == 23
            && CableScript.totalTile3 == 27)
        {
            unlockText.SetActive(true);
        }
    }
}
