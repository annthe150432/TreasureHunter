using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClockHandler : MonoBehaviour
{
    CountdownTimer countdownTimer;
    Text text;
    // Start is called before the first frame update
    void Start()
    {
        countdownTimer = gameObject.AddComponent<CountdownTimer>();
        countdownTimer.Duration = 90;
        countdownTimer.Run();
        text = gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (countdownTimer.Running)
        {
            int minutes = (int)(countdownTimer.Duration / 60);
            int seconds = (int)(countdownTimer.Duration % 60);
            text.text = $"{minutes}:{seconds.ToString("D2")}";
        }
    }
}
