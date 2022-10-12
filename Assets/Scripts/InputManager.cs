using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerInput _playerInput;
    private PlayerInput.OnFootActions _onFoot;

    private PlayerMotor _motor;
    private PlayerLook _look;

    void Awake()
    {
        _playerInput = new PlayerInput();
        _onFoot = _playerInput.OnFoot;

        _motor = GetComponent<PlayerMotor>();
        _look = GetComponent<PlayerLook>();

        //anytime jump is performed we use call back context(ctx) to call our funtion.

        _onFoot.Jump.performed += ctx => _motor.Jump();
        _onFoot.Crouch.performed += ctx => _motor.Crouch();
        _onFoot.Sprint.performed += ctx => _motor.Sprint();
    }

    void FixedUpdate()
    {
        //tell the playermotor to move along the value from the movement action

        _motor.ProcessMove(_onFoot.Movement.ReadValue<Vector2>());

    }

    private void LateUpdate()
    {
        _look.ProcessLook(_onFoot.Look.ReadValue<Vector2>());
    }

    private void OnEnable()
    {
        _onFoot.Enable();
    }

    private void OnDisable()
    {
        _onFoot.Disable();
    }
}
