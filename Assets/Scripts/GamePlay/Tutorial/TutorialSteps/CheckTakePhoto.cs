using UnityEngine;

namespace Drone.Scripts.GamePlay.Tutorial
{
    public class CheckTakePhoto : TutorialStepAbstract
    {
        [SerializeField] private CameraController _cameraController;
        
        public override void EnterStep()
        {
            _cameraController.OnTakePhoto += GoNext;
        }

        public override void UpdateState()
        {
            
        }

        public override void ExitStep()
        {
            _cameraController.OnTakePhoto -= GoNext;
        }

        private void GoNext()
        {
            TutorialController.instance.GoNext();
        }
    }
}