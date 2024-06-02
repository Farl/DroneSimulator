using UnityEngine;

namespace Drone.Scripts.GamePlay.Tutorial
{
    public class CheckZoom : TutorialStepAbstract
    {
        [SerializeField] private float checkTime;

        private float _timer;
        
        public override void EnterStep()
        {
            _timer = 0;
        }

        public override void UpdateState()
        {
            if (Mathf.Abs(InputManager.instance.Zoom) > 0.1)
            {
                _timer += Time.deltaTime;

                if (_timer > checkTime)
                {
                    TutorialController.instance.GoNext();
                }
            }
        }

        public override void ExitStep()
        {
            
        }
    }
}