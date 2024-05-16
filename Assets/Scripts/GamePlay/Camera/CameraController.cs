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
        [Header("Zoom")]
        [SerializeField] private float minFOV;
        [SerializeField] private float maxFOV;
        [SerializeField] private float zoomSpeed;

        [SerializeField] private Camera _camera;

        private float _timer;

        private void Start()
        {
            _inputManager = InputManager.instance;

            _inputManager.OnActionMapSwitch += map =>
            {
                if (map == ActionMap.Drone)
                {
                    transform.DOLocalRotate(Vector3.zero, 1f);
                }
            };

            _timer = 0;
        }

        private void Update()
        {
            CheckStateButtons();
            
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
            var hAngel = transform.localRotation.eulerAngles.y 
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
            
            var vAngel = transform.localRotation.eulerAngles.x 
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
            
            transform.localRotation = Quaternion.Euler(vAngel, hAngel, 0);
        }

        private void UpdateZoom()
        {
            var fov = _camera.fieldOfView - (zoomSpeed * _inputManager.Zoom * Time.deltaTime);

            if(fov < minFOV)
            { fov = minFOV; }
            else if(fov > maxFOV) 
            {  fov = maxFOV; }
            _camera.fieldOfView = fov;
        }

        private void CheckStateButtons()
        {
            if (_inputManager.RightButton == 1
                && _inputManager.LeftButton == 0
               )
            {
                _timer += Time.deltaTime;
                if (_timer >= 1.0f)
                {
                    _inputManager.SwitchActionMap();
                    _timer = 0;
                }
            }
        }
    }
}