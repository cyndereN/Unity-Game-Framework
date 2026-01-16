using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
/// <summary>
/// Event Center Manager. Used to add command events, remove command events, and dispatch commands.
/// Using this manager, when multiple objects listen for a command and it is dispatched, they will automatically execute the corresponding logic.
/// </summary>
public class EventCenterManager : SingletonBase<EventCenterManager>
{
	// Key represents the command.
	// Value represents the logic to execute.
	Dictionary<string, IEventInfo> eventsDictionary = new Dictionary<string, IEventInfo>();

	/// <summary>
	/// Add a command event with no parameters
	/// </summary>
	/// <param name="command">The command to listen for (typically a custom enum).</param>
	/// <param name="call">Delegate to execute when the command is received.</param>
	public void AddListener(object command, UnityAction call)
	{
		string key = command.GetType().Name + "_" + command.ToString();
		// If the event name already exists in the dictionary, add the handler; otherwise create a new key-value pair in the dictionary for this event.
		if (eventsDictionary.ContainsKey(key))
			(eventsDictionary[key] as EventInfo).action += call;
		else
			eventsDictionary.Add(key, new EventInfo(call));
	}

	/// <summary>
	/// Add a command event with one parameter
	/// </summary>
	/// <typeparam name="T">Type of the command's parameter</typeparam>
	/// <param name="command">The command to listen for (typically a custom enum).</param>
	/// <param name="call">Delegate to execute when the command is received.</param>
	public void AddListener<T>(object command, UnityAction<T> call)
	{
		string key = command.GetType().Name + "_" + command.ToString() + "_" + typeof(T).Name;
		// If the event name already exists in the dictionary, add the handler; otherwise create a new key-value pair in the dictionary for this event.
		if (eventsDictionary.ContainsKey(key))
			(eventsDictionary[key] as EventInfo<T>).action += call;
		else
			eventsDictionary.Add(key, new EventInfo<T>(call));
	}

	/// <summary>
	/// Add a command event with two parameters
	/// </summary>
	/// <typeparam name="T0">Type of the first parameter</typeparam>
	/// <typeparam name="T1">Type of the second parameter</typeparam>
	/// <param name="command">The command to listen for (typically a custom enum).</param>
	/// <param name="call">Delegate to execute when the command is received.</param>
	public void AddListener<T0, T1>(object command, UnityAction<T0, T1> call)
	{
		string key = command.GetType().Name + "_" + command.ToString() + "_" + typeof(T0).Name + "_" + typeof(T1).Name;
		// If the event name already exists in the dictionary, add the handler; otherwise create a new key-value pair in the dictionary for this event.
		if (eventsDictionary.ContainsKey(key))
			(eventsDictionary[key] as EventInfo<T0, T1>).action += call;
		else
			eventsDictionary.Add(key, new EventInfo<T0, T1>(call));
	}

	/// <summary>
	/// Add a command event with three parameters
	/// </summary>
	/// <typeparam name="T0">Type of the first parameter</typeparam>
	/// <typeparam name="T1">Type of the second parameter</typeparam>
	/// <typeparam name="T2">Type of the third parameter</typeparam>
	/// <param name="command">The command to listen for (typically a custom enum).</param>
	/// <param name="call">Delegate to execute when the command is received.</param>
	public void AddListener<T0, T1, T2>(object command, UnityAction<T0, T1, T2> call)
	{
		string key = command.GetType().Name + "_" + command.ToString() + "_" + typeof(T0).Name + "_" + typeof(T1).Name + "_" + typeof(T2).Name;
		// If the event name already exists in the dictionary, add the handler; otherwise create a new key-value pair in the dictionary for this event.
		if (eventsDictionary.ContainsKey(key))
			(eventsDictionary[key] as EventInfo<T0, T1, T2>).action += call;
		else
			eventsDictionary.Add(key, new EventInfo<T0, T1, T2>(call));
	}

	/// <summary>
	/// Add a command event with four parameters
	/// </summary>
	/// <typeparam name="T0">Type of the first parameter</typeparam>
	/// <typeparam name="T1">Type of the second parameter</typeparam>
	/// <typeparam name="T2">Type of the third parameter</typeparam>
	/// <typeparam name="T3">Type of the fourth parameter</typeparam>
	/// <param name="command">The command to listen for (typically a custom enum).</param>
	/// <param name="call">Delegate to execute when the command is received.</param>
	public void AddListener<T0, T1, T2, T3>(object command, UnityAction<T0, T1, T2, T3> call)
	{
		string key = command.GetType().Name + "_" + command.ToString() + "_" + typeof(T0).Name + "_" + typeof(T1).Name + "_" + typeof(T2).Name + "_" + typeof(T3).Name;
		// If the event name already exists in the dictionary, add the handler; otherwise create a new key-value pair in the dictionary for this event.
		if (eventsDictionary.ContainsKey(key))
			(eventsDictionary[key] as EventInfo<T0, T1, T2, T3>).action += call;
		else
			eventsDictionary.Add(key, new EventInfo<T0, T1, T2, T3>(call));
	}

	/// <summary>
	/// Remove a command event with no parameters
	/// </summary>
	/// <param name="command">The command to stop listening for.</param>
	/// <param name="call">The delegate method to remove.</param>
	public void RemoveListener(object command, UnityAction call)
	{
		string key = command.GetType().Name + "_" + command.ToString();
		// If the dictionary contains the command to remove, remove it.
		if (eventsDictionary.ContainsKey(key))
			(eventsDictionary[key] as EventInfo).action -= call;
	}

	/// <summary>
	/// Remove all parameterless event listeners for a command
	/// </summary>
	/// <param name="command">The command to stop listening for.</param>
	public void RemoveListeners(object command)
	{
		string key = command.GetType().Name + "_" + command.ToString();
		// If the dictionary contains the command to remove, clear all its event handlers.
		if (eventsDictionary.ContainsKey(key))
			(eventsDictionary[key] as EventInfo).action = null;
	}

	/// <summary>
	/// Remove a command event with one parameter
	/// </summary>
	/// <typeparam name="T">Type of the parameter</typeparam>
	/// <param name="command">The command to stop listening for.</param>
	/// <param name="call">The delegate method to remove.</param>
	public void RemoveListener<T>(object command, UnityAction<T> call)
	{
		string key = command.GetType().Name + "_" + command.ToString() + "_" + typeof(T).Name;
		// If the dictionary contains the command to remove, remove it.
		if (eventsDictionary.ContainsKey(key))
			(eventsDictionary[key] as EventInfo<T>).action -= call;
	}

	/// <summary>
	/// Remove all event listeners with one parameter for a command
	/// </summary>
	/// <typeparam name="T">Type of the parameter</typeparam>
	/// <param name="command">The command to stop listening for.</param>
	public void RemoveListeners<T>(object command)
	{
		string key = command.GetType().Name + "_" + command.ToString() + "_" + typeof(T).Name;
		// If the dictionary contains the command to remove, clear all its event handlers.
		if (eventsDictionary.ContainsKey(key))
			(eventsDictionary[key] as EventInfo<T>).action = null;
	}

	/// <summary>
	/// Remove a command event with two parameters
	/// </summary>
	/// <typeparam name="T0">Type of the first parameter</typeparam>
	/// <typeparam name="T1">Type of the second parameter</typeparam>
	/// <param name="command">The command to stop listening for.</param>
	/// <param name="call">The delegate method to remove.</param>
	public void RemoveListener<T0, T1>(object command, UnityAction<T0, T1> call)
	{
		string key = command.GetType().Name + "_" + command.ToString() + "_" + typeof(T0).Name + "_" + typeof(T1).Name;
		// If the dictionary contains the command to remove, remove it.
		if (eventsDictionary.ContainsKey(key))
			(eventsDictionary[key] as EventInfo<T0, T1>).action -= call;
	}

	/// <summary>
	/// Remove all event listeners with two parameters for a command
	/// </summary>
	/// <typeparam name="T0">Type of the first parameter</typeparam>
	/// <typeparam name="T1">Type of the second parameter</typeparam>
	/// <param name="command">The command to stop listening for.</param>
	public void RemoveListeners<T0, T1>(object command)
	{
		string key = command.GetType().Name + "_" + command.ToString() + "_" + typeof(T0).Name + "_" + typeof(T1).Name;
		// If the dictionary contains the command to remove, clear all its event handlers.
		if (eventsDictionary.ContainsKey(key))
			(eventsDictionary[key] as EventInfo<T0, T1>).action = null;
	}

	/// <summary>
	/// Remove a command event with three parameters
	/// </summary>
	/// <typeparam name="T0">Type of the first parameter</typeparam>
	/// <typeparam name="T1">Type of the second parameter</typeparam>
	/// <typeparam name="T2">Type of the third parameter</typeparam>
	/// <param name="command">The command to stop listening for.</param>
	/// <param name="call">The delegate method to remove.</param>
	public void RemoveListener<T0, T1, T2>(object command, UnityAction<T0, T1, T2> call)
	{
		string key = command.GetType().Name + "_" + command.ToString() + "_" + typeof(T0).Name + "_" + typeof(T1).Name + "_" + typeof(T2).Name;
		// If the dictionary contains the command to remove, remove it.
		if (eventsDictionary.ContainsKey(key))
			(eventsDictionary[key] as EventInfo<T0, T1, T2>).action -= call;
	}

	/// <summary>
	/// Remove all event listeners with three parameters for a command
	/// </summary>
	/// <typeparam name="T0">Type of the first parameter</typeparam>
	/// <typeparam name="T1">Type of the second parameter</typeparam>
	/// <typeparam name="T2">Type of the third parameter</typeparam>
	/// <param name="command">The command to stop listening for.</param>
	public void RemoveListeners<T0, T1, T2>(object command)
	{
		string key = command.GetType().Name + "_" + command.ToString() + "_" + typeof(T0).Name + "_" + typeof(T1).Name + "_" + typeof(T2).Name;
		// If the dictionary contains the command to remove, clear all its event handlers.
		if (eventsDictionary.ContainsKey(key))
			(eventsDictionary[key] as EventInfo<T0, T1, T2>).action = null;
	}

	/// <summary>
	/// Remove a command event with four parameters
	/// </summary>
	/// <typeparam name="T0">Type of the first parameter</typeparam>
	/// <typeparam name="T1">Type of the second parameter</typeparam>
	/// <typeparam name="T2">Type of the third parameter</typeparam>
	/// <typeparam name="T3">Type of the fourth parameter</typeparam>
	/// <param name="command">The command to stop listening for.</param>
	/// <param name="call">The delegate method to remove.</param>
	public void RemoveListener<T0, T1, T2, T3>(object command, UnityAction<T0, T1, T2, T3> call)
	{
		string key = command.GetType().Name + "_" + command.ToString() + "_" + typeof(T0).Name + "_" + typeof(T1).Name + "_" + typeof(T2).Name + "_" + typeof(T3).Name;
		// If the dictionary contains the command to remove, remove it.
		if (eventsDictionary.ContainsKey(key))
			(eventsDictionary[key] as EventInfo<T0, T1, T2, T3>).action -= call;
	}

	/// <summary>
	/// Remove all event listeners with four parameters for a command
	/// </summary>
	/// <typeparam name="T0">Type of the first parameter</typeparam>
	/// <typeparam name="T1">Type of the second parameter</typeparam>
	/// <typeparam name="T2">Type of the third parameter</typeparam>
	/// <typeparam name="T3">Type of the fourth parameter</typeparam>
	/// <param name="command">The command to stop listening for.</param>
	public void RemoveListeners<T0, T1, T2, T3>(object command)
	{
		string key = command.GetType().Name + "_" + command.ToString() + "_" + typeof(T0).Name + "_" + typeof(T1).Name + "_" + typeof(T2).Name + "_" + typeof(T3).Name;
		// If the dictionary contains the command to remove, clear all its event handlers.
		if (eventsDictionary.ContainsKey(key))
			(eventsDictionary[key] as EventInfo<T0, T1, T2, T3>).action = null;
	}

	/// <summary>
	/// Remove all events from the Event Center. Consider calling this when switching scenes.
	/// </summary>
	public void RemoveAllListeners()
	{
		eventsDictionary.Clear();
	}

	/// <summary>
	/// Dispatch a command with no parameters.
	/// </summary>
	/// <param name="command">The command to dispatch.</param>
	public void Dispatch(object command)
	{
		string key = command.GetType().Name + "_" + command.ToString();
		// If the event name exists in the dictionary and the event is not null, invoke it; otherwise do nothing.
		if (eventsDictionary.ContainsKey(key))
			(eventsDictionary[key] as EventInfo).action?.Invoke();
	}

	/// <summary>
	/// Dispatch a command with one parameter
	/// </summary>
	/// <typeparam name="T">Type of the parameter</typeparam>
	/// <param name="command">The command to dispatch.</param>
	/// <param name="parameter">The parameter to pass with the command. External code can perform different logic based on this value.</param>
	public void Dispatch<T>(object command, T parameter)
	{
		string key = command.GetType().Name + "_" + command.ToString() + "_" + typeof(T).Name;
		// If the event name exists in the dictionary and the event is not null, invoke it; otherwise do nothing.
		if (eventsDictionary.ContainsKey(key))
			(eventsDictionary[key] as EventInfo<T>).action?.Invoke(parameter);
	}

	/// <summary>
	/// Dispatch a command with two parameters
	/// </summary>
	/// <typeparam name="T0">Type of the first parameter</typeparam>
	/// <typeparam name="T1">Type of the second parameter</typeparam>
	/// <param name="command">The command to dispatch.</param>
	/// <param name="parameter0">First parameter of the event</param>
	/// <param name="parameter1">Second parameter of the event</param>
	public void Dispatch<T0, T1>(object command, T0 parameter0, T1 parameter1)
	{
		string key = command.GetType().Name + "_" + command.ToString() + "_" + typeof(T0).Name + "_" + typeof(T1).Name;
		// If the event name exists in the dictionary and the event is not null, invoke it; otherwise do nothing.
		if (eventsDictionary.ContainsKey(key))
			(eventsDictionary[key] as EventInfo<T0, T1>).action?.Invoke(parameter0, parameter1);
	}

	/// <summary>
	/// Dispatch a command with three parameters
	/// </summary>
	/// <typeparam name="T0">Type of the first parameter</typeparam>
	/// <typeparam name="T1">Type of the second parameter</typeparam>
	/// <typeparam name="T2">Type of the third parameter</typeparam>
	/// <param name="command">The command to dispatch.</param>
	/// <param name="parameter0">First parameter of the event</param>
	/// <param name="parameter1">Second parameter of the event</param>
	/// <param name="parameter2">Third parameter of the event</param>
	public void Dispatch<T0, T1, T2>(object command, T0 parameter0, T1 parameter1, T2 parameter2)
	{
		string key = command.GetType().Name + "_" + command.ToString() + "_" + typeof(T0).Name + "_" + typeof(T1).Name + "_" + typeof(T2).Name;
		// If the event name exists in the dictionary and the event is not null, invoke it; otherwise do nothing.
		if (eventsDictionary.ContainsKey(key))
			(eventsDictionary[key] as EventInfo<T0, T1, T2>).action?.Invoke(parameter0, parameter1, parameter2);
	}

	/// <summary>
	/// Dispatch a command with four parameters
	/// </summary>
	/// <typeparam name="T0">Type of the first parameter</typeparam>
	/// <typeparam name="T1">Type of the second parameter</typeparam>
	/// <typeparam name="T2">Type of the third parameter</typeparam>
	/// <typeparam name="T3">Type of the fourth parameter</typeparam>
	/// <param name="command">The command to dispatch.</param>
	/// <param name="parameter0">First parameter of the event</param>
	/// <param name="parameter1">Second parameter of the event</param>
	/// <param name="parameter2">Third parameter of the event</param>
	/// <param name="parameter3">Fourth parameter of the event</param>
	public void Dispatch<T0, T1, T2, T3>(object command, T0 parameter0, T1 parameter1, T2 parameter2, T3 parameter3)
	{
		string key = command.GetType().Name + "_" + command.ToString() + "_" + typeof(T0).Name + "_" + typeof(T1).Name + "_" + typeof(T2).Name + "_" + typeof(T3).Name;
		// If the event name exists in the dictionary and the event is not null, invoke it; otherwise do nothing.
		if (eventsDictionary.ContainsKey(key))
			(eventsDictionary[key] as EventInfo<T0, T1, T2, T3>).action?.Invoke(parameter0, parameter1, parameter2, parameter3);
	}

	/// <summary>
	/// Print information about the key-value pairs in the Event Center's events dictionary to the console
	/// </summary>
	public void PrintEventsDictionaryInfo()
	{
		Debug.Log($"There are {eventsDictionary.Count} kv pairs");

		int i = 0;
		foreach (KeyValuePair<string, IEventInfo> item in eventsDictionary)
		{
			Debug.Log($"The {i}th Key ks{item.Key}");
			i++;
		}
	}

	private interface IEventInfo { }// Used for the Liskov Substitution Principle

	private class EventInfo : IEventInfo
	{
		public UnityAction action;

		public EventInfo(UnityAction call)
		{
			action += call;
		}
	}

	private class EventInfo<T> : IEventInfo
	{
		public UnityAction<T> action;

		public EventInfo(UnityAction<T> call)
		{
			action += call;
		}
	}

	private class EventInfo<T0, T1> : IEventInfo
	{
		public UnityAction<T0, T1> action;

		public EventInfo(UnityAction<T0, T1> call)
		{
			action += call;
		}
	}

	private class EventInfo<T0, T1, T2> : IEventInfo
	{
		public UnityAction<T0, T1, T2> action;

		public EventInfo(UnityAction<T0, T1, T2> call)
		{
			action += call;
		}
	}

	private class EventInfo<T0, T1, T2, T3> : IEventInfo
	{
		public UnityAction<T0, T1, T2, T3> action;

		public EventInfo(UnityAction<T0, T1, T2, T3> call)
		{
			action += call;
		}
	}
}
