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
    public GameObject fusebox;
    public GameObject target;

    public List<GameObject> cables;


    public void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        cables = new List<GameObject>(GameObject.FindGameObjectsWithTag("Cable"));
    }

    // Method to reset a scene
    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            spriteRenderer.sprite = OGSprite;
            //SceneManager.LoadScene(sceneName);
            foreach (GameObject cable in cables) {
                cable.GetComponent<CableScript>().resetItem();
            }
            
            
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
