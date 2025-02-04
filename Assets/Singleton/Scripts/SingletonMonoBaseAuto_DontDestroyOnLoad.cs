using UnityEngine;

public class SingletonMonoBaseAuto_DontDestroyOnLoad<T> : MonoBehaviour where T : MonoBehaviour
{

	protected SingletonMonoBaseAuto_DontDestroyOnLoad() { }

	// 记录单例对象是否存在，防止在OnDestroy()方法中访问单例对象报错
	public static bool IsCreated { get; private set; } = false;

	private static T instance;
	public static T Instance
	{
		get
		{
			if (instance == null)
			{
				instance = FindAnyObjectByType<T>();

				if (instance == null)
				{
					// 创建游戏对象
					GameObject obj = new GameObject(typeof(T).Name, new[] { typeof(T) });
					// 挂载脚本
					instance = obj.AddComponent<T>();
					IsCreated = true;
					DontDestroyOnLoad(obj);
				}
			}
			return instance;
		}
	}

	protected virtual void OnDestroy()
	{
		IsCreated = false;
	}
}
