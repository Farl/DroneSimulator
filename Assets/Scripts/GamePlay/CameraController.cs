using System;
using UnityEngine;
using DG.Tweening;

namespace Drone.Scripts.GamePlay
{
    public class CameraController : MonoBehaviour
    {
        private InputManager _inputManager;
        
        [Header("Rotation Angels")]
        [SerializeField] private float minHorizontalAngel;
        [SerializeField] private float maxHorizontalAngel;
        [SerializeField] private float minVerticalAngel;
        [SerializeField] private float maxVerticalAngel;
        [Header("Rotation Speed")]
        [SerializeField] private float horizontalSpeed;
        [SerializeField] private float verticalSpeed;

        private void Start()
        {
            _inputManager = GameObject.FindGameObjectWithTag("Input").GetComponent<InputManager>();

            _inputManager.OnActionMapSwitch += map =>
            {
                if (map == ActionMap.Drone)
                {
                    transform.DORotate(Vector3.zero, 1f);
                }
            };
        }

        private void Update()
        {
            if(_inputManager.ActionMap != ActionMap.Camera)
                return;
            ProcessCameraRotations();
        }

        private void ProcessCameraRotations()
        {
            UpdateRotation();
            UpdateZoom();
        }

        private void UpdateRotation()
        {
            var hAngel = transform.rotation.eulerAngles.y 
                         + (horizontalSpeed * _inputManager.RightLeftRotation * Time.deltaTime);

            hAngel = hAngel > 180 ? hAngel - 360 : hAngel;

            if (hAngel < minHorizontalAngel)
            {
                hAngel = minHorizontalAngel;
            }
            else if (hAngel > maxHorizontalAngel)
            {
                hAngel = maxHorizontalAngel;
            }
            
            var vAngel = transform.rotation.eulerAngles.x 
                         + (verticalSpeed * _inputManager.UpDownRotation * Time.deltaTime * -1);

            vAngel = vAngel > 180 ? vAngel - 360 : vAngel;
            
            if (vAngel < minVerticalAngel)
            {
                vAngel = minVerticalAngel;
            }
            else if (vAngel > maxVerticalAngel)
            {
                vAngel = maxVerticalAngel;
            }
            
            transform.rotation = Quaternion.Euler(vAngel, hAngel, 0);
        }

        private void UpdateZoom()
        {
            
        }

        
    }
}