using System.Collections;
using UnityEngine;

public class MonoTest : MonoBehaviour
{
	Player player;

	private void Awake()
	{
		player = new Player();
	}

	// For testing purposes
	void OnGUI()
	{
		if(GUI.Button(new Rect(0,0,100,50), "Start Coroutine"))
		{
			player.Show();
		}

		if (GUI.Button(new Rect(0, 80, 100, 50), "Stop Coroutine"))
		{
			player.Hide();
		}

		if (GUI.Button(new Rect(0, 160, 100, 50), "Stop All Coroutine"))
		{
			player.HideAll();
		}

		if (GUI.Button(new Rect(160, 0, 200, 50), "Add Update Event"))
		{
			player.PrintUpdate();
		}

		if (GUI.Button(new Rect(160, 80, 200, 50), "Remove Update Event"))
		{
			player.StopPrintUpdate();
		}

		if (GUI.Button(new Rect(160, 160, 200, 50), "Remove All Update Events"))
		{
			player.StopAllPrintUpdate();
		}
	}

	IEnumerator MyCoroutine()
	{
		while (true)
		{
			Debug.Log("Executing MyCoroutine");
			yield return null;
		}
	}
}
