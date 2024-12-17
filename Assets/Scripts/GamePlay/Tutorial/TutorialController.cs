using System;
using Drone.Scripts.GamePlay;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Drone.Scripts.GamePlay.Tutorial;
using UnityEngine;

//todo: переделать, поменять стейты, чтоы было удобнее с ними работать
public class TutorialController : MonoBehaviour
{
    public static TutorialController instance;

    public Action TutorialIsOver;

    [SerializeField] private TutorialUI tutorialUI;
    
    private List<TutorialStepAbstract> _steps = new List<TutorialStepAbstract>();
    private TutorialStepAbstract _currentStepObject;
    private int _currentTutorialID;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            
            var steps = FindObjectsOfType<TutorialStepAbstract>();
            _steps = steps.OrderBy(i => i.ID).ToList();

            if (_steps.Count > 0)
            {
                _currentStepObject = _steps[0];
                _currentTutorialID = 0;
                _currentStepObject.EnterStep();
            }

            return;
        }
        
        Destroy(gameObject);
    }

    public void GoNext()
    {
        _currentStepObject.ExitStep();
        _currentTutorialID++;

        if (_currentTutorialID < _steps.Count)
        {
            _currentStepObject = _steps[_currentTutorialID];
            _currentStepObject.EnterStep();
            tutorialUI.GoNext();
        }
        else
        {
            TutorialIsOver?.Invoke();
            tutorialUI.GoNext();
        }
    }

    private void Update()
    {
        _currentStepObject.UpdateState();
    }
}
