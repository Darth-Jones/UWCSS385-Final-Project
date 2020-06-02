using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reset : MonoBehaviour
{
    public string sceneName;
    private SpriteRenderer spriteRenderer;
    public Sprite OGSprite;
    public Sprite newSprite;

    public void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Method to reset a scene
    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            spriteRenderer.sprite = OGSprite;
            SceneManager.LoadScene(sceneName);
            CableScript.ResetVariables();
        }
    }

    private void OnMouseOver()
    {
        if (!Input.GetMouseButtonDown(0))
        {
            spriteRenderer.sprite = newSprite;
        }
        
    }

    private void OnMouseExit()
    {
        spriteRenderer.sprite = OGSprite;
    }
}
