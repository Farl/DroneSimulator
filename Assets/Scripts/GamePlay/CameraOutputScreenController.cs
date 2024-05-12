using System.Collections;
using System.Collections.Generic;
using Drone.Scripts.GamePlay;
using UnityEngine;

public class CameraOutputScreenController : MonoBehaviour
{
    [SerializeField] private GameObject screenGameObject;

    [SerializeField] private GameObject cameraFrameGameObject;
    [SerializeField] private GameObject droneHUDGameObject;

    private InputManager _inputManager;
    
    // Start is called before the first frame update
    void Start()
    {
        _inputManager = GameObject.FindGameObjectWithTag("Input").GetComponent<InputManager>();
        
        _inputManager.OnActionMapSwitch += OnActionMapSwitch;
    }

    private void OnActionMapSwitch(ActionMap map)
    {
        if (map == ActionMap.Camera)
        {
            cameraFrameGameObject.SetActive(true);
            droneHUDGameObject.SetActive(false);
        }
        else
        {
            cameraFrameGameObject.SetActive(false);
            droneHUDGameObject.SetActive(true);
        }
    }
}
