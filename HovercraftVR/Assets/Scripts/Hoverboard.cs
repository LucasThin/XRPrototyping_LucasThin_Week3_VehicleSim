using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Hoverboard : MonoBehaviour
{
    [SerializeField] private GameObject _hoverboard;
    [SerializeField] private InputActionReference _hoverBoardActivate;
    
    void Start()
    {
        _hoverboard.SetActive(false);
        _hoverBoardActivate.action.performed += ActivateHoverBoard;
    }

    private void ActivateHoverBoard(InputAction.CallbackContext obj)
    {
        Debug.Log("Activate HoverBoard");
        _hoverboard.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
