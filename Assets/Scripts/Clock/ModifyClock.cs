using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModifyClock : MonoBehaviour
{
    public Timer timer;
    void Start()
    {
        timer = gameObject.AddComponent<Timer>();
        timer.Duration = 2;
    }
    private void Update()
    {
        if (timer.Finished)
        {
            GameObject clock = gameObject.transform.GetChild(0).gameObject;
            CountdownTimer countdownTimer = clock.GetComponent<ClockHandler>().countdownTimer.GetComponent<CountdownTimer>();
            countdownTimer.AddedDuration = 0;
            GameObject addedTime = gameObject.transform.GetChild(1).gameObject;
            addedTime.SetActive(false);
        }
        if (Input.GetMouseButtonDown(0))
        {
            ModifyClockCounting(-5);
        }
    }

    public void ModifyClockCounting(float modifyAmount)
    {
        if (timer.Running)
        {
            return;
        }
        GameObject clock = gameObject.transform.GetChild(0).gameObject;
        CountdownTimer countdownTimer = clock.GetComponent<ClockHandler>().countdownTimer.GetComponent<CountdownTimer>();
        countdownTimer.AddedDuration = modifyAmount;
        countdownTimer.AddDuration(countdownTimer.Duration);
        GameObject addedTime = gameObject.transform.GetChild(1).gameObject;
        addedTime.GetComponent<Text>().text = (modifyAmount > 0) ? "+" + modifyAmount.ToString() : modifyAmount.ToString();
        addedTime.SetActive(true);
        timer.Run();
    }
}
