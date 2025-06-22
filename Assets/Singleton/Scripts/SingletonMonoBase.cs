using UnityEngine;

public class SingletonMonoBase<T> : MonoBehaviour where T : MonoBehaviour
{
    protected SingletonMonoBase() { }

	//  Records whether the singleton object exists to prevent errors when accessing the singleton object in the OnDestroy() method
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
