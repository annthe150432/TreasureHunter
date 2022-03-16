using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentPointHandler : MonoBehaviour
{
    public bool RestartLevel = false;
    void Start()
    {
        Text value = GetComponent<Text>();
        value.text = LevelDataManagement.Instance.Current.ToString();
    }

    private void OnDestroy()
    {
        Text value = GetComponent<Text>();
        if (!RestartLevel)
            LevelDataManagement.Instance.UpdateLevelData(current: int.Parse(value.text));
    }
}
