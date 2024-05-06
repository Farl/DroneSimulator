using System;
using System.Collections;
using System.Collections.Generic;
using Drone.Scripts.GamePlay;
using Unity.VisualScripting;
using UnityEngine;

public class RemoteControllerHandler : MonoBehaviour
{
    [SerializeField] private float stickRotationAngel;

    [SerializeField] private Transform leftStick;
    [SerializeField] private Transform rightStick;

    private InputManager _inputManager;

    private void Start()
    {
        _inputManager = GameObject.FindGameObjectWithTag("Input").GetComponent<InputManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_inputManager.ActionMap == ActionMap.Drone)
        {
            leftStick.transform.localRotation = Quaternion.Euler(
                -_inputManager.Cyclic.y * stickRotationAngel, 
                -_inputManager.Cyclic.x * stickRotationAngel, 
                0);
            rightStick.transform.localRotation = Quaternion.Euler(
                -_inputManager.Throttle * stickRotationAngel, 
                -_inputManager.Pedals * stickRotationAngel, 0);
        }
        else
        {
            leftStick.transform.localRotation = Quaternion.Euler(
                -_inputManager.UpDownRotation * stickRotationAngel, 
                -_inputManager.RightLeftRotation * stickRotationAngel, 
                0);
            rightStick.transform.localRotation = Quaternion.Euler(
                -_inputManager.Zoom * stickRotationAngel,
                0, 0);
        }
    }
}
