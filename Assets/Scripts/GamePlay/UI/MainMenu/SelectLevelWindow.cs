using DG.Tweening;
using TMPro;
using UnityEngine;

namespace Drone.Scripts.GamePlay
{
    public class SelectLevelWindow : MonoBehaviour
    {
        public TMP_Text DescriptionText;

        public void CloseWindow()
        {
            transform.DOScale(0, 0.3f);
        }
    }
}