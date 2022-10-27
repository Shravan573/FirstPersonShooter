using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    //Add or remove interactionEvent comp to this gameobject
    public bool useEvents;

    //message displayed to the player when lookting at interactable.
    [SerializeField]
    public string promptMessage;

    public virtual string OnLook()
    {
        return promptMessage;
    }

    //this fucntion will be called from our player.
    public void BaseInteract()
    {
        if (useEvents)
        {
            GetComponent<InteractionEvents>().OnInteract.Invoke();
        }
        Interact();
    }

    protected virtual void Interact()
    {
        //we wont have any code here
        //this is a template function to be overwritten ny our subclasses.
    }
}
