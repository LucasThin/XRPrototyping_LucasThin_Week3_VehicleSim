using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class Hoverboard : MonoBehaviour
{
    [SerializeField] private GameObject _hoverboard;
    [SerializeField] private Transform _forwardSource;
    [SerializeField] private Transform _mainCamera;
    [SerializeField] private GameObject _XROrigin;
    [SerializeField] private GameObject _Avatar;
    [SerializeField] private InputActionReference _hoverBoardActivate;
    [SerializeField] private InputActionReference _HoverUpDown;
    [SerializeField] private InputActionReference _RotateLeftRight;
    [SerializeField] private ActionBasedContinuousMoveProvider _XROriginMove;
    [SerializeField] private ActionBasedContinuousTurnProvider _XROriginTurn;

    [SerializeField] private Transform[] _bones = new Transform[7];
    [SerializeField] private Transform[] _skatePose = new Transform[7];
    [SerializeField] private Transform[] _standPose = new Transform[7];
    [SerializeField] private float turnSpeed = 250;

  
    [SerializeField] private AudioSource _HoverSound;
    [SerializeField] private AudioSource _hoverActivateSound;
    
    private Vector3 _Ground;

    private bool _hoverboardState = false;
    void Start()
    {
        _hoverboard.SetActive(false);
        _hoverBoardActivate.action.performed += ActivateHoverBoard;
        _HoverUpDown.action.performed += UpDown;
        _RotateLeftRight.action.performed += LeftRight;

    }

    private void LeftRight(InputAction.CallbackContext obj)
    {
        float val = obj.ReadValue<float>();
        
        if (_hoverboardState)
        {
            if (val > 0.55)
            {
                
                _XROrigin.transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed);
                _Avatar.transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed);
                _HoverSound.Play();
            } else if (val < -0.55)
            {
                _XROrigin.transform.Rotate(Vector3.up * Time.deltaTime * -turnSpeed);
                _Avatar.transform.Rotate(Vector3.up * Time.deltaTime * -turnSpeed);
                _HoverSound.Play();
            }
        }
    }

    private void UpDown(InputAction.CallbackContext obj)
    {
        float val = obj.ReadValue<float>();

        if (_hoverboardState)
        {
            if (val > 0.95)
            {
                _XROrigin.transform.Translate(Vector3.up * Time.deltaTime * 2, Space.World);
                _Avatar.transform.Translate(Vector3.up * Time.deltaTime * 2, Space.World);
                _HoverSound.Play();
            } else if (val < -0.95)
            {
                _XROrigin.transform.Translate(Vector3.down * Time.deltaTime * 2, Space.World);
                _Avatar.transform.Translate(Vector3.down * Time.deltaTime * 2, Space.World);
                _HoverSound.Play();
            }
        }
        
    }

    private void ActivateHoverBoard(InputAction.CallbackContext obj)
    {
        Debug.Log("Activate HoverBoard");

        if (_hoverboard.activeSelf)
        {
            _hoverboard.SetActive(false);
            
            for (int i = 0; i < 7; i++)
            {
                _bones[i].rotation = _standPose[i].rotation;
            }

            _hoverboardState = false;

        }
        else
        {
            _hoverboard.SetActive(true);
            _hoverActivateSound.PlayOneShot(_hoverActivateSound.clip);
            for (int i = 0; i < 7; i++)
            {
                _bones[i].rotation = _skatePose[i].rotation;
            }
            
            _hoverboardState = true;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (_hoverboardState)
        {
            //_XROriginTurn.enabled = false;
            _XROriginMove.forwardSource = _forwardSource;
        } 
        
        else if (!_hoverboardState) 
        {
            //_XROriginTurn.enabled = true;
            _XROriginMove.forwardSource = _mainCamera;
            
            
        }
    }
}
