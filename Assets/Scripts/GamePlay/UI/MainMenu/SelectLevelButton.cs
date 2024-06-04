using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Drone.Scripts.GamePlay
{
    public class SelectLevelButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        public string sceneName;
        [TextArea(2, 3)]
        public string sceneDescription;
        [Header("UI Elements")]
        [SerializeField] private SelectLevelWindow window;

        public void OnClickButton()
        {
            SceneManager.LoadScene(sceneName);
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            window.DescriptionText.text = sceneDescription;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            window.DescriptionText.text = "";
        }
    }
}