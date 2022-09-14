using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Hoverboard : MonoBehaviour
{
    [SerializeField] private GameObject _hoverboard;
    [SerializeField] private InputActionReference _hoverBoardActivate;

    [SerializeField] private Transform[] _bones = new Transform[7];
    [SerializeField] private Transform[] _skatePose = new Transform[7];
    [SerializeField] private Transform[] _standPose = new Transform[7];
    
   /* //Save skating poses
    [SerializeField] private Transform _back;
    [SerializeField] private Transform _leftFoot;
    [SerializeField] private Transform _leftShin;
    [SerializeField] private Transform _leftThigh;
    [SerializeField] private Transform _rightFoot;
    [SerializeField] private Transform _rightShin;
    [SerializeField] private Transform _rightThigh;
    
    //Stand Pose
    [SerializeField] private Transform _Sback;
    [SerializeField] private Transform _SleftFoot;
    [SerializeField] private Transform _SleftShin;
    [SerializeField] private Transform _SleftThigh;
    [SerializeField] private Transform _SrightFoot;
    [SerializeField] private Transform _SrightShin;
    [SerializeField] private Transform _SrightThigh; */
    
    void Start()
    {
        _hoverboard.SetActive(false);
        _hoverBoardActivate.action.performed += ActivateHoverBoard;

        
    }

    private void ActivateHoverBoard(InputAction.CallbackContext obj)
    {
        Debug.Log("Activate HoverBoard");
        _hoverboard.SetActive(true);

        for (int i = 0; i < 7; i++)
        {
            _bones[i].rotation = _skatePose[i].rotation;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
