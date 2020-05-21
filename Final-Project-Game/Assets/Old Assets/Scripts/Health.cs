using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHP;
    private float currentHP;
    private float opacity;
    private float xAnchor;
    private float yAnchor;

    public GameObject uiCounter;
    // Start is called before the first frame update
    void Start()
    {
        currentHP = maxHP;
        xAnchor = transform.position.x;
        yAnchor = transform.position.y;
        opacity = 1f;
        uiCounter = GameObject.Find("UI");
    }

    // Update is called once per frame
    void Update()
    {


    }

    public void updateHealth()
    {
        currentHP--;

        // apply the fade witht he alpha channel thingy

        if (currentHP == 0)
        {
            if (tag.Contains("nemy"))
            {
                uiCounter.GetComponent<UITracking>().PlaneKilledByEgg();
                Destroy(gameObject);
            }
            else
            {
                changeLocation();
            }
        }
        else
        {
            opacity -= (1f / maxHP);
            SpriteRenderer sprite = gameObject.GetComponent<SpriteRenderer>();
            sprite.color = new Color(1f, 1f, 1f, opacity);
        }

    }
    void changeLocation()
    {
        float xTrans = Random.Range(-15, 16);
        float yTrans = Random.Range(-15, 16);

        xTrans += xAnchor;
        yTrans += yAnchor;

        transform.position = new Vector2(xTrans, yTrans);
        currentHP = maxHP;

        opacity = 1f;
        SpriteRenderer sprite = gameObject.GetComponent<SpriteRenderer>();
        sprite.color = new Color(1f, 1f, 1f, opacity);
    }
}

