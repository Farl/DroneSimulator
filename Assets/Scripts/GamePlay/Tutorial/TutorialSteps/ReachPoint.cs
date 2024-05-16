using System;
using UnityEngine;

namespace Drone.Scripts.GamePlay.Tutorial
{
    public class ReachPoint : TutorialStepAbstract
    {
        [SerializeField] private GameObject pointGameObject;

        private void OnTriggerEnter(Collider other)
        {
            if (other.transform.parent.GetComponent<DroneMainScript>()
                || other.GetComponent<DroneMainScript>())
            {
                TutorialController.instance.GoNext();
            }
        }

        public override void EnterStep()
        {
            pointGameObject.SetActive(true);
        }

        public override void UpdateState()
        {
            
        }

        public override void ExitStep()
        {
            pointGameObject.SetActive(false);
        }
    }
}