using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressTracker : MonoBehaviour
{
    [SerializeField] private TutorialManager tutorialManager;
    [SerializeField] private PathController pathController;
    
    
    // Start is called before the first frame update
    void Start()
    {
        pathController.OnPointReached += () =>
        {
            tutorialManager.GoNext();
        };
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
