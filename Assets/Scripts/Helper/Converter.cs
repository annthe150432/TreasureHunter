using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Converter
{
    public static Vector2 getVector2DByDegree(float degree)
    {
        float radian = degree * Mathf.Deg2Rad;
        float sinD = Mathf.Sin(radian);
        float cosD = Mathf.Cos(radian);
        float x = sinD;
        float y = cosD;
        return new Vector2(x, y);
    }
}


