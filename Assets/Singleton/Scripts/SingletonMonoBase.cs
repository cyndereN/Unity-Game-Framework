using UnityEngine;

public class SingletonMonoBase<T> : MonoBehaviour where T : MonoBehaviour
{
    protected SingletonMonoBase() { }

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

                if (instance != null)
                {
					IsCreated = true;
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
