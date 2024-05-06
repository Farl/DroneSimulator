using Drone.Scripts.GamePlay;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DroneStatsUpdate : MonoBehaviour
{
    [Header("RC UI")]
    [SerializeField] private TMP_Text heightText;

    private DroneController _droneController;

    private void Awake()
    {
        _droneController = FindAnyObjectByType<DroneController>();
    }

    private void Update()
    {
        var currentHeight = ((int)_droneController.transform.position.y).ToString();

        if(heightText.text != currentHeight)
        {
            heightText.text = currentHeight;
        }
    }
}
