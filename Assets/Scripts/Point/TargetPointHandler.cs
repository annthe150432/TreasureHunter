using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetPointHandler : MonoBehaviour
{
    
    void Start()
    {
        GameObject targetMoney = GameObject.FindGameObjectWithTag("TargetMoney");
        Text value = targetMoney.GetComponent<Text>(); 
        value.text = LevelDataManagement.Instance.Target.ToString();

    }
}
