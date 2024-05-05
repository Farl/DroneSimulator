using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Drone.Scripts.GamePlay
{
    public enum ActionMap
    {
        Drone,
        Camera
    }
    [RequireComponent(typeof(PlayerInput))]
    public class InputManager : MonoBehaviour
    {
        #region Variables
        
        public ActionMap ActionMap => _actionMap;

        public Action<ActionMap> OnActionMapSwitch;

        public Vector2 Cyclic => _cyclic;
        public float Pedals => _pedals;
        public float Throttle => _throttle;
        public float Switch => _switch;
        public float RightLeftRotation => _rightLeftRotation;
        public float UpDownRotation => _upDownRotation;
        public float Zoom => _zoom;

        private Vector2 _cyclic;
        private float _pedals;
        private float _throttle;
        private float _switch;
        private float _rightLeftRotation;
        private float _upDownRotation;
        private float _zoom;

        private PlayerInput _input;
        private ActionMap _actionMap;
        private float timer;

        #endregion

        #region Main Methods

        private void Awake()
        {
            _input = GetComponent<PlayerInput>();
        }

        void Update()
        {
            if (_switch == 1)           //switching control modes
            {
                timer += Time.deltaTime;
                if (timer >= 1.0f)
                {
                    _actionMap = _actionMap == ActionMap.Drone ? ActionMap.Camera : ActionMap.Drone;
                    _input.currentActionMap = _input.actions.FindActionMap(_actionMap.ToString());
                    timer = 0;
                    OnActionMapSwitch?.Invoke(_actionMap);
                    
                    
                }
            }
        }

        #endregion

        #region Input Methods

        private void OnCyclic(InputValue value)
        {
            _cyclic = value.Get<Vector2>();
            
        }

        private void OnPedals(InputValue value)
        {
            _pedals = value.Get<float>();
        }

        private void OnThrottle(InputValue value)
        {
            _throttle = value.Get<float>();
        }

        private void OnSwitch(InputValue value)
        {
            _switch = value.Get<float>();
        }

        private void OnRightLeftRotation(InputValue value)
        {
            _rightLeftRotation = value.Get<float>();
        }

        private void OnUpDownRotation(InputValue value)
        {
            _upDownRotation = value.Get<float>();
        }

        private void OnZoom(InputValue value)
        {
            _zoom = value.Get<float>();
        }
        #endregion
    }
}

