using UnityEngine;
using DG.Tweening;

public class MainMenuScript : MonoBehaviour
{
    [SerializeField] private GameObject selectLevelWindow;

    private void Start()
    {
        selectLevelWindow.transform.localScale = Vector3.zero;
    }

    public void OpenLevelSelectWindow()
    {
        selectLevelWindow.transform.DOScale(1, 0.3f);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
