using UnityEngine;

public class SingletonMonoBaseAuto<T> : MonoBehaviour where T : MonoBehaviour
{
	protected SingletonMonoBaseAuto() { }

	// ��¼���������Ƿ���ڣ���ֹ��OnDestroy()�����з��ʵ������󱨴�
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
					// ������Ϸ����
					GameObject obj = new GameObject(typeof(T).Name, new[] { typeof(T) });
					// ���ؽű�
					instance = obj.AddComponent<T>();
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
