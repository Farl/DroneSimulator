using Drone.Scripts.GamePlay;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressTracker : MonoBehaviour
{
    [SerializeField] private TutorialManager tutorialManager;
    [SerializeField] private PathController pathController;

    [Space(10)]
    [Header("QuestParameters")]
    [SerializeField] private int targetHeight;

    private QuestProgressState _progressState;
    private DroneController _droneController;
    
    
    // Start is called before the first frame update
    void Start()
    {
        _progressState = QuestProgressState.GoUp;
        _droneController = FindAnyObjectByType<DroneController>();

        pathController.OnPointReached += () =>
        {
            tutorialManager?.GoNext();
        };
        pathController.OnPathEnded += () =>
        {
            _progressState = QuestProgressState.Land;
        };
    }

    // Update is called once per frame
    void Update()
    {
        if(_progressState == QuestProgressState.GoUp)
        {
            if(_droneController.transform.position.y >= targetHeight)
            {
                tutorialManager?.GoNext();
                _progressState = QuestProgressState.FollowPath;
                pathController.gameObject.SetActive(true);
                
            }
        }
    }
}

public enum QuestProgressState
{
    TurnOn,
    GoUp,
    FollowPath,
    Land,
    TurnOff
}