using UnityEngine;

namespace Drone.Scripts.GamePlay.Tutorial
{
    public class CheckGrounded : TutorialStepAbstract
    {
        [SerializeField] private DroneMainScript drone;
        
        public override void EnterStep()
        {
            
        }

        public override void UpdateState()
        {
            if (drone.isGrounded)
            {
                TutorialController.instance.GoNext();
            }
        }

        public override void ExitStep()
        {
            
        }
    }
}