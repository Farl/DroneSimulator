using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerZoneScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            Debug.Log("drone in");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            Debug.Log("drone out");
        }
    }
}
