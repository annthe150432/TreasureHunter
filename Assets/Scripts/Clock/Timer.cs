using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    // timer duration
    protected float totalSeconds = 0;

	// timer execution
	protected float elapsedSeconds = 0;
	protected bool running = false;

	// support for Finished property
	protected bool started = false;

	/// <summary>
	/// Sets the duration of the timer
	/// The duration can only be set if the timer isn't currently running
	/// </summary>
	/// <value>duration</value>
	public float Duration
	{
        get
        {
			return totalSeconds;
        }
		set
		{
			totalSeconds = value;
		}
	}

	/// <summary>
	/// Gets whether or not the timer has finished running
	/// This property returns false if the timer has never been started
	/// </summary>
	/// <value>true if finished; otherwise, false.</value>
	public bool Finished
	{
		get { return started && !running; }
	}

	/// <summary>
	/// Gets whether or not the timer is currently running
	/// </summary>
	/// <value>true if running; otherwise, false.</value>
	public bool Running
	{
		get { return running; }
	}

	// Update is called once per frame
	protected virtual void Update()
    {
		// update timer and check for finished
		if (running)
		{
			elapsedSeconds += Time.deltaTime;
			if (elapsedSeconds >= totalSeconds)
			{
				running = false;
			}
		}
	}

	/// <summary>
	/// Runs the timer
	/// Because a timer of 0 duration doesn't really make sense,
	/// the timer only runs if the total seconds is larger than 0
	/// This also makes sure the consumer of the class has actually 
	/// set the duration to something higher than 0
	/// </summary>
	public void Run()
	{
		// only run with valid duration
		if (totalSeconds > 0)
		{
			started = true;
			running = true;
			elapsedSeconds = 0;
		}
	}
}
