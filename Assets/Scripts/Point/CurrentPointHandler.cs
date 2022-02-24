using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentPointHandler : MonoBehaviour
{
    Point point;
    bool addPoint = false;
    public int TargetPoint = 0;
    // Start is called before the first frame update
    void Start()
    {
        point = gameObject.AddComponent<Point>();
        point.TargetPoint = TargetPoint;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
