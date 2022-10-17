using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColorCube : Interactable
{
    MeshRenderer _mesh;
    public Color[] _color;
    private int _colorIndex;

    private void Start()
    {
        _mesh = GetComponent<MeshRenderer>();
        _mesh.material.color = Color.red;
    }

    protected override void Interact()
    {
        _colorIndex++;
        if (_colorIndex > _color.Length - 1)
        {
            _colorIndex = 0;
        }

        _mesh.material.color = _color[_colorIndex];
    }
}
