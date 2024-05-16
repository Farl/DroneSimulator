namespace Drone.Scripts.GamePlay.Tutorial
{
    public interface ITutorialStep
    {
        int ID { get; }
        void EnterStep();
        void UpdateState();
        void ExitStep();
    }
}