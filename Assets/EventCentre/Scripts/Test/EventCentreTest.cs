using UnityEngine;

public class EventCentreTest : MonoBehaviour
{
	private void OnGUI()
	{
		if (GUI.Button(new Rect(0,0,125,50), "Fire Command 1"))
		{
			EventCenterManager.Instance.Dispatch(E_EventCommand.Work);
		}

		if (GUI.Button(new Rect(0, 80, 125, 50), "Remove all events on Command 1"))
		{
			EventCenterManager.Instance.RemoveListeners(E_EventCommand.Work);
		}

		if (GUI.Button(new Rect(150, 0, 125, 50), "Fire Command 2"))
		{
			EventCenterManager.Instance.Dispatch(E_EventCommand.Fire);
		}


		if (GUI.Button(new Rect(150, 80, 125, 50), "Remove all events on Command 2"))
		{
			EventCenterManager.Instance.RemoveListeners(E_EventCommand.Fire);
		}

		if (GUI.Button(new Rect(0, 200, 200, 50), "Fire a parameterized command"))
		{
			EventCenterManager.Instance.Dispatch<int>(E_EventCommand.LevelUp, 1);
		}

		if (GUI.Button(new Rect(200, 200, 200, 50), "Remove all events of that parameterized command"))
		{
			EventCenterManager.Instance.RemoveListeners<int>(E_EventCommand.LevelUp);
		}
	}


	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Q))
		{
			StopwatchUtility.PrintTime(() =>
			{
				string T = "Work".GetType().Name;
			}, 1000);
		}
	}
}
