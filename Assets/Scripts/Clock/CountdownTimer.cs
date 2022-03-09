using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountdownTimer : Timer
{
    public const float BaseDuration = 10;
    public float AddedDuration { get; set; } = 0;

    private void Awake()
    {
        AddedDuration = LevelDataManagement.Instance.AddedTime;
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

    public void AddDuration(float baseDuration)
    {
        Duration = baseDuration + AddedDuration;
    }
}
