using System;
using UnityEngine;

namespace Drone.Scripts.GamePlay.Tutorial
{
    public abstract class TutorialStepAbstract : MonoBehaviour, ITutorialStep
    {
        public int ID => id;

        [SerializeField] private int id;
        

        public abstract void EnterStep();

        public abstract void UpdateState();

        public abstract void ExitStep();
    }
}