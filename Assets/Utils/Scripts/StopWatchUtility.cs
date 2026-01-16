using System;
using UnityEngine.Events;
using System.Diagnostics;
/// <summary>
/// Utility class for Stopwatch. Used to measure the time taken to run a block of code.
/// </summary>
public static class StopwatchUtility
{
	/// <summary>
	/// Gets the TimeSpan representing the execution time of a code block.
	/// </summary>
	/// <param name="call">The code to execute</param>
	public static TimeSpan GetTime(UnityAction call)
	{
		Stopwatch timer = Stopwatch.StartNew();// create and start the stopwatch
		timer.Start();// start the stopwatch
		call?.Invoke();// execute the code
		timer.Stop();// stop the stopwatch
		return timer.Elapsed;// return elapsed time
	}

	/// <summary>
	/// Prints the execution time of a code block to the console in seconds.
	/// </summary>
	/// <param name="call">The code to execute</param>
	/// <param name="executionNumber">Number of times to execute. Must be a positive integer; otherwise the method is invalid and a warning will be logged to the console.</param>
	public static void PrintTime(UnityAction call, int executionNumber = 1)
	{
		// ensure executionNumber is a positive integer.
		if (executionNumber <= 0)
		{
			UnityEngine.Debug.LogWarning("Stopwatch performance test failed! executionNumber should be a positive integer.");
			return;
		}

		// records the total elapsed time in milliseconds.
		double totalMilliseconds = 0;

		// execute the code multiple times and accumulate the execution time.
		for (int i = 0; i < executionNumber; i++)
		{
			totalMilliseconds += GetTime(call).TotalMilliseconds;
		}

		// print the total execution time to the console
		UnityEngine.Debug.Log($"Execution time for running this code {executionNumber} times is {totalMilliseconds / 1000} seconds");
	}
}
