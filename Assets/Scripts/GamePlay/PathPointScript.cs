using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathPointScript : MonoBehaviour
{
    public Action OnPathPointReached;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == GameConstData.DroneGameObjectlayer)
        {
            OnPathPointReached?.Invoke();
            gameObject.SetActive(false);
        }
    }
}
