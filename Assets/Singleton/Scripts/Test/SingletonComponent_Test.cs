using UnityEngine;

public class SingletonComponent_Test : SingletonMonoBase<SingletonComponent_Test>
{
	private SingletonComponent_Test() { }

	public int money = 666;
	public int diamond = 8888;
	public void Show()
	{
		Debug.Log("SingletonMonoBase: SingletonComponent_Test");
	}
}
