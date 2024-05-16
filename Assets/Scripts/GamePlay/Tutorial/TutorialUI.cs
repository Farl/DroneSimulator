using System;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TutorialUI : MonoBehaviour
{
    public Action TutorialEnded;
    [SerializeField] private TMP_Text tutorialText;
    [SerializeField] private Image executingMark;
    [SerializeField] private Image executedMark;
    [SerializeField] private GameObject finalText;
    [SerializeField] private string configName;

    private TutorialConfig _config;
    private int _current = 0;
    

    void Start()
    {
        _config = Resources.Load<TutorialConfig>($"Configs/{configName}");

        tutorialText.text = _config.Phrases[_current];
    }

    public void GoNext()
    {
        if (_current < _config.Phrases.Length - 1)
        {
            executingMark.gameObject.SetActive(false);
            executedMark.gameObject.SetActive(true);

            PlayTextChangeAnimation(1);
        }
        else
        {
            tutorialText.gameObject.SetActive(false);
            executedMark.gameObject.SetActive(false);
            executingMark.gameObject.SetActive(false);
            finalText.SetActive(true);
            TutorialEnded?.Invoke();
        }
    }

    private void PlayTextChangeAnimation(float duration)
    {
        var seq = DOTween.Sequence();

        seq.Append(executingMark.material.DOFade(0, duration));
        seq.Join(executedMark.material.DOFade(0, duration));
        seq.Join(tutorialText.DOFade(0, duration)
            .OnComplete(() =>
            {
                tutorialText.text = _config.Phrases[++_current];
                executedMark.gameObject.SetActive(false);
                executingMark.gameObject.SetActive(true);
            }));
        seq.Append(executingMark.material.DOFade(1, duration));
        seq.Join(executedMark.material.DOFade(1, duration));
        seq.Join(tutorialText.DOFade(1, duration));
    }
}
