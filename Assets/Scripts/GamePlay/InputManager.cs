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

        public static InputManager instance;
        
        public ActionMap ActionMap => _actionMap;

        public Action<ActionMap> OnActionMapSwitch;

        public Vector2 Cyclic => _cyclic;
        public float Pedals => _pedals;
        public float Throttle => _throttle;
        public float RightButton => _rightButton;
        public float LeftButton => _leftButton;
        public float RightLeftRotation => _rightLeftRotation;
        public float UpDownRotation => _upDownRotation;
        public float Zoom => _zoom;

        private Vector2 _cyclic;
        private float _pedals;
        private float _throttle;
        private float _rightButton;
        private float _leftButton;
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
            if (instance == null)
            {
                instance = this;
                _input = GetComponent<PlayerInput>();
                return;
            }
            
            Destroy(this);
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

        private void OnRightButton(InputValue value)
        {
            _rightButton = value.Get<float>();
        }
        
        private void OnLeftButton(InputValue value)
        {
            _leftButton = value.Get<float>();
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

        #region Custom Methods

        public void SwitchActionMap()
        {
            _actionMap = _actionMap == ActionMap.Drone ? ActionMap.Camera : ActionMap.Drone;
            _input.currentActionMap = _input.actions.FindActionMap(_actionMap.ToString());
            OnActionMapSwitch?.Invoke(_actionMap);
        }

        #endregion
    }
}

