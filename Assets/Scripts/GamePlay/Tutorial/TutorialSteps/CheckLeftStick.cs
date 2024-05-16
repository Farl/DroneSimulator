using UnityEngine;

namespace Drone.Scripts.GamePlay.Tutorial
{
    public class CheckLeftStick : TutorialStepAbstract
    {
        [SerializeField] private float checkTime;

        private float _timer;
        
        public override void EnterStep()
        {
            _timer = 0;
        }

        public override void UpdateState()
        {
            if (InputManager.instance.Cyclic.magnitude > 0.5f)
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