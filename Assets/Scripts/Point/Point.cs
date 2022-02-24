using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    int targetPoint = 0;
    int currentPoint = 0;
    public int TargetPoint
    {
        get
        {
            return targetPoint;
        }
        set
        {
            targetPoint = value;
        }
    }
    public int CurrentPoint
    {
        get
        {
            return currentPoint;
        }
        set
        {
            currentPoint = value;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
