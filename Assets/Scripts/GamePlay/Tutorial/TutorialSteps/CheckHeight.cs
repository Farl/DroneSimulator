using UnityEngine;

namespace Drone.Scripts.GamePlay.Tutorial
{
    public class CheckHeight : TutorialStepAbstract
    {
        [SerializeField] private DroneMainScript drone;
        [SerializeField] private float height;
        
        public override void EnterStep()
        {
            
        }

        public override void UpdateState()
        {
            if(drone.groundHeight > height)
                TutorialController.instance.GoNext();
        }

        public override void ExitStep()
        {
            
        }
    }
}