using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private Camera _cam;
    [SerializeField]
    private float distance = 3f;
    [SerializeField]
    private LayerMask _mask;
    private PlayerUI _playerUI;
    private InputManager _inputManager;

    private void Start()
    {
        _cam = GetComponent<PlayerLook>()._cam;
        _playerUI = GetComponent<PlayerUI>();
        _inputManager = GetComponent<InputManager>();
    }

    private void Update()
    {
        _playerUI.UpdateText(string.Empty);
        Ray ray = new Ray(_cam.transform.position, _cam.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * distance);
        RaycastHit hitInfo; //local varible to store our collison info
        if(Physics.Raycast(ray, out hitInfo, distance, _mask))
        {
            if(hitInfo.collider.GetComponent<Interactable>() != null)
            {
                Interactable _interactable = hitInfo.collider.GetComponent<Interactable>();
                _playerUI.UpdateText(_interactable.promptMessage);
                if (_inputManager._onFoot.Interact.triggered)
                {
                    _interactable.BaseInteract();
                }

            }
        }
    }
}
