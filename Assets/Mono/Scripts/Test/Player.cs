using System.Collections;
using UnityEngine;

public class Player
{
	Coroutine coroutine;

	public void Show()
	{
		// Test1: Get the obj with monoscript and call coroutine on this 
		//GameObject go = GameObject.Find("MonoController");
		//go.AddComponent<MonoController>().StartCoroutine(MyCoroutine());

		coroutine = MonoManager.Instance.StartCoroutine(MyCoroutine());
	}

	public void Hide()
	{
		MonoManager.Instance.StopCoroutine(coroutine);
	}

	public void HideAll()
	{
		MonoManager.Instance.StopAllCoroutines();
	}

	public void PrintUpdate()
	{
		MonoManager.Instance.AddUpdateListener(DebugUpdate);
	}

	public void StopPrintUpdate()
	{
		MonoManager.Instance.RemoveUpdateListener(DebugUpdate);
	}

	public void StopAllPrintUpdate()
	{
		MonoManager.Instance.RemoveAllUpdateListeners();
	}

	void DebugUpdate()
	{
		// Better not to use Lambda
		Debug.Log("Update");
	}

	IEnumerator MyCoroutine()
	{
		while (true)
		{
			Debug.Log("Executing MyCoroutine...");
			yield return null;
		}
	}
}
