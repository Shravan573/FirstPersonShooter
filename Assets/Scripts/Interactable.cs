using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    //message displayed to the player when lookting at interactable.
    public string promptMessage;

    //this fucntion will be called from our player.
    public void BaseInteract()
    {
        Interact();
    }

    protected virtual void Interact()
    {
        //we wont have any code here
        //this is a template function to be overwritten ny our subclasses.
    }
}
