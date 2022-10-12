using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController _controller;
    private Vector3 _playerVelocity;

    private bool isGrounded;
    private bool _lerpCrouch;
    private bool _crouching;
    private bool _sprinting;

    public float _gravity = -9.8f;
    public float speed = 5f;
    public float _jumpHeight = 3.0f;
    public float _crouchTimer;

    private void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        isGrounded = _controller.isGrounded;

        if (_lerpCrouch)
        {
            _crouchTimer += Time.deltaTime;
            float p = _crouchTimer / 1;
            p *= p;
            if (_crouching)
            {
                _controller.height = Mathf.Lerp(_controller.height, 1, p);
            }
            else
            {
                _controller.height = Mathf.Lerp(_controller.height, 2, p);
            }
            if (p > 1)
            {
                _lerpCrouch = false;
                _crouchTimer = 0f;
            }
        }
    }

    // recieve inputs from InputManager.cs and apply them to character controller.
    public void ProcessMove(Vector2 _input)
    {
        Vector3 _moveDirection = Vector3.zero;
        _moveDirection.x = _input.x;
        _moveDirection.z = _input.y;

        _controller.Move(transform.TransformDirection(_moveDirection) * speed * Time.deltaTime);
        _playerVelocity.y += _gravity * Time.deltaTime;

        if(isGrounded &&_playerVelocity.y < 0)
        {
            _playerVelocity.y = -2.0f;
        }

        _controller.Move(_playerVelocity * Time.deltaTime);
    }

    public void Jump()
    {
        if (isGrounded)
        {
            _playerVelocity.y = Mathf.Sqrt(_jumpHeight * -3.0f * _gravity);
        }
    }

    public void Crouch()
    {
        _crouching = !_crouching;
        _crouchTimer = 0;
        _lerpCrouch = true;
    }

    public void Sprint()
    {
        _sprinting = !_sprinting;
        if (_sprinting)
        {
            speed = 8;
        }
        else
        {
            speed = 5;
        }
    }
}
