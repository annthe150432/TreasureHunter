using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountdownTimer : Timer
{
    // Update is called once per frame
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
}
