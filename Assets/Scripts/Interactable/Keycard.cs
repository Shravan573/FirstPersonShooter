using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keycard : Interactable
{
    [SerializeField]
    private GameObject _door;
    private bool _doorOpen;


    //this function is where we will design our interaction using code.
    protected override void Interact()
    {
        _doorOpen = !_doorOpen;
        _door.GetComponent<Animator>().SetBool("IsOpen", _doorOpen);
    }
}
