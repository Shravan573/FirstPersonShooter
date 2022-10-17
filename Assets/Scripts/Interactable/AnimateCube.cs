using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateCube : Interactable
{
    Animator _animator;
    private string _startPrompt;

    private void Start()
    {
        _animator = GetComponent<Animator>();
       _startPrompt = promptMessage;
    }

    private void Update()
    {
        if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Default"))
        {
            promptMessage = _startPrompt;
        }
        else
        {
            promptMessage = "Animating...";
        }
    }

    protected override void Interact()
    {
        _animator.Play("Spin");
    }
}
