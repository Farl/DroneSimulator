using UnityEngine;

namespace Drone.Scripts.GamePlay.Tutorial
{
    public class CheckStabilizationMode : TutorialStepAbstract
    {
        [SerializeField] private bool targetState;
        
        public override void EnterStep()
        {
            
        }

        public override void UpdateState()
        {
            if (targetState == true)
            {
                if (InputManager.instance.ActionMap == ActionMap.Camera)
                {
                    TutorialController.instance.GoNext();
                }
            }
            else
            {
                if (InputManager.instance.ActionMap == ActionMap.Drone)
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