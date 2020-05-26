using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Interactable"))
        {
            inInteractionZone = !inInteractionZone;
            interactionObject = collision.gameObject;
            InteractionObject interactionScript = interactionObject.GetComponent<InteractionObject>();
            interactionScript.Triggered("enter");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Interactable"))
        {
            inInteractionZone = !inInteractionZone;
            interactionObject = collision.gameObject;
            InteractionObject interactionScript = interactionObject.GetComponent<InteractionObject>();
            interactionScript.Triggered("exit");
        }
    }
}
