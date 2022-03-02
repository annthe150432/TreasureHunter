using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountdownTimer : Timer
{
    public const float BaseDuration = 5;
    public float AddedDuration { get; set; } = 5;

    private void Start()
    {
        AddDuration();
    }
    protected override void Update()
    {
		// update timer and check for finished
		if (running)
		{
			totalSeconds -= Time.deltaTime;
            if (totalSeconds <= 0)
            {
                running = false;
            }
		}
	}

    public void AddDuration()
    {
        Duration = BaseDuration + AddedDuration;
    }
}
