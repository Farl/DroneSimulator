using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    [SerializeField] TMP_Text tutorialText;
    [SerializeField] string configName;

    TutorialConfig config;
    

    void Start()
    {
        config = Resources.Load<TutorialConfig>($"Configs/{configName}");

        tutorialText.text = config.Phrases[0];
    }

    
}
