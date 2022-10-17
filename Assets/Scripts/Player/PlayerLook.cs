using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public Camera _cam;
    private float _xRotation = 0f;

    public float _xSensititvity = 30.0f;
    public float _ySensitivity = 30.0f;

    public void ProcessLook(Vector2 _input)
    {
        float mouseX = _input.x;
        float mouseY = _input.y;

        //calculate camera rotation for looking up and down.
        _xRotation -= (mouseY * Time.deltaTime) * _ySensitivity;
        _xRotation = Mathf.Clamp(_xRotation, -80f, 80f);

        //apply this to our camera transform.
        _cam.transform.localRotation = Quaternion.Euler(_xRotation, 0, 0);

        //rotate player to look left and right.
        transform.Rotate(Vector3.up * (mouseX * Time.deltaTime) * _xSensititvity);
    }

}
