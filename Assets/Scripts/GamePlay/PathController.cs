using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathController : MonoBehaviour
{
    public Action OnPathEnded;
    public Action OnPointReached;

    [SerializeField] List<PathPointScript> pathPointsList = new List<PathPointScript>();

    private int counter = 0;

    void Start()
    {
        foreach (var point in pathPointsList)
        {
            point.OnPathPointReached += GetNextPoint;
            point.gameObject.SetActive(false);
        }

        StartPath();
    }

    private void GetNextPoint()
    {
        OnPointReached?.Invoke();
        
        pathPointsList[counter].gameObject.SetActive(false);
        counter++;
        if(counter < pathPointsList.Count)
        {
            pathPointsList[counter].gameObject.SetActive(true);
        }
        else
        {
            OnPathEnded?.Invoke();
        }
    }

    public void StartPath(int pos = 0)
    {
        pathPointsList[pos].gameObject.SetActive(true);
    }
}
