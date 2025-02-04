using UnityEngine;

public class MyUIManager : SingletonMonoBaseAuto_DontDestroyOnLoad<MyUIManager>
{
	// 构造方法私有化，防止外部new对象
	private MyUIManager() { }

	public void Show()
	{
		Debug.Log("UI Manager");
	}

	public void Hide()
	{
		Debug.Log("Hide UI Manager");
	}

	protected override void OnDestroy()
	{
		Show();
	}
}

//public class MyUIManager : MonoBehaviour
//{
//	// 构造方法私有化，防止外部new对象
//	private MyUIManager() { }

//	// 提供一个属性给外部访问，这个属性就相当于是单例对象
//	private static MyUIManager instance;

//	public static MyUIManager Instance
//	{
//		get
//		{
//			// 保证对象唯一性
//			if (instance == null)
//			{
//				instance = FindAnyObjectByType<MyUIManager>();

//				// 自动挂载
//				if (instance == null) 
//				{
//					GameObject UIManager = new GameObject("MyUIManager");
//					instance = UIManager.AddComponent<MyUIManager>();

//					// 让游戏对象在切换场景之后不销毁
//					DontDestroyOnLoad(UIManager);
//				}
//			}

//			return instance;
//		}
//	}

//	public void Show()
//	{
//		Debug.Log("UI Manager");
//	}

//	public void Hide()
//	{
//		Debug.Log("Hide UI Manager");
//	}
//}
