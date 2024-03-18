using Drone.Scripts.GamePlay;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotationController : MonoBehaviour
{
    [SerializeField] InputManager input;
    [SerializeField] float minHorizontalRotation;
    [SerializeField] float maxHorizontalRotation;
    [SerializeField] float minVerticalRotation;
    [SerializeField] float maxVerticallRotation;
    [SerializeField] float speed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (input.RightLeftRotation == 1 || input.RightLeftRotation == -1)
        {
            
        }
        if(input.UpDownRotation == 1 || input.UpDownRotation == -1)
        {
            
        }
        if(input.Zoom == 1 || input.Zoom == -1)
        {

        }
    }
}
