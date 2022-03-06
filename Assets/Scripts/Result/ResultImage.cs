using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultImage : MonoBehaviour
{
    private void Awake()
    {
        if (LevelDataManagement.Instance.Current < LevelDataManagement.Instance.Target)
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            gameObject.transform.GetChild(1).gameObject.SetActive(true);
        }
        else
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            gameObject.transform.GetChild(1).gameObject.SetActive(false);
        }
    }
}
