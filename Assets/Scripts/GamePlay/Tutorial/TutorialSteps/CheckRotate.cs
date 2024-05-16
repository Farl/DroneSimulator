using UnityEngine;

namespace Drone.Scripts.GamePlay.Tutorial
{
    public class CheckRotate : TutorialStepAbstract
    {
        [SerializeField] private float checkTime;

        private float _timer;
        
        public override void EnterStep()
        {
            _timer = 0;
        }

        public override void UpdateState()
        {
            if (InputManager.instance.Pedals == 1)
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