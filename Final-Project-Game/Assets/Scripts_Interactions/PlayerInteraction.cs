using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField]
    private bool inInteractionZone = false;
    private GameObject interactionObject;

    // Update is called once per frame
    void Update()
    {
        if (inInteractionZone)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                InteractionObject interactionScript = interactionObject.GetComponent<InteractionObject>();
                interactionScript.Triggered("click");
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        inInteractionZone = !inInteractionZone;
        interactionObject = collision.gameObject;
        InteractionObject interactionScript = interactionObject.GetComponent<InteractionObject>();
        interactionScript.Triggered("enter");
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        inInteractionZone = !inInteractionZone;
        interactionObject = collision.gameObject;
        InteractionObject interactionScript = interactionObject.GetComponent<InteractionObject>();
        interactionScript.Triggered("exit");
    }
}
