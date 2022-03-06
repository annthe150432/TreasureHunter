using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetPointHandler : MonoBehaviour
{
    void Start()
    {
        Text value = GetComponent<Text>();
        value.text = LevelDataManagement.Instance.Target.ToString();
    }
}
