using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadDataDynamite : MonoBehaviour
{
    private Text textDynamiteCount;
    // Start is called before the first frame update
    void Start()
    {
        textDynamiteCount = GameObject.FindGameObjectWithTag("DynamiteCount").GetComponent<Text>();        
    }

    // Update is called once per frame
    void Update()
    {
        textDynamiteCount.text ="x" + LevelDataManagement.Instance.DynamiteCount.ToString(); 
    }
}
