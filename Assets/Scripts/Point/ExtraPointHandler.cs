using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExtraPointHandler : MonoBehaviour
{
    Timer timer;
    public Text text { get; set; }
    void Start()
    {
        timer = gameObject.AddComponent<Timer>();
        timer.Duration = 1.3f;
        text = gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer.Finished)
        {
            text.text = "";
        }
    }

    public void AddPoint(int point)
    {
        text.text = "+" + point.ToString() + "$";
        timer.Run();
    }
}
