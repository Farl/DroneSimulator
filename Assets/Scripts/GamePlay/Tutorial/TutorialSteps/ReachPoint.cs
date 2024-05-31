using System;
using UnityEngine;

namespace Drone.Scripts.GamePlay.Tutorial
{
    public class ReachPoint : TutorialStepAbstract
    {
        [SerializeField] private GameObject pointBody;
        [SerializeField] private Collider collider;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == GameConstData.DroneGameObjectlayer)
            {
                collider.enabled = false;
                pointBody.SetActive(false);
                TutorialController.instance.GoNext();
            }
        }

        public override void EnterStep()
        {
            pointBody.SetActive(true);
        }

        public override void UpdateState()
        {
            
        }

        public override void ExitStep()
        {
            
        }
    }
}