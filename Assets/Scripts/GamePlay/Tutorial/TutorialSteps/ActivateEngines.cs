using System;
using Unity.VisualScripting;
using UnityEngine;

namespace Drone.Scripts.GamePlay.Tutorial
{
    public class ActivateEngines : TutorialStepAbstract
    {
        [SerializeField] private DroneMainScript drone;
        
        private float _timer;

        public override void EnterStep()
        {
            if (drone.enabled)
                drone.enabled = false;
        }

        public override void UpdateState()
        {
            if (InputManager.instance.RightButton == 0 && InputManager.instance.LeftButton == 1)
            {
                _timer += Time.deltaTime;
                if (_timer > 1)
                {
                    TutorialController.instance.GoNext();
                }
            }
        }

        public override void ExitStep()
        {
            drone.enabled = true;
        }
    }
}