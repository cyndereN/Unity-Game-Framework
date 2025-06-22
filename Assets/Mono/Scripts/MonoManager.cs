using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

/// <summary>
/// Enable coroutine support in non-MonoBehaviour classes while retaining access to FixedUpdate, Update, and LateUpdate methods.
/// </summary>
public class MonoManager : SingletonBase<MonoManager>
{
	// Private ctor to prevent instanciate from outer
	private MonoManager() { }


	// Executer for mono properties
	private MonoController monoExecuter;
	private MonoController MonoExecuter
	{
		get
		{
			// Make sure a game object with MonoController exists
			if (monoExecuter == null)	
			{
				GameObject go = new GameObject(typeof(MonoController).Name); // Same as ¡°MonoController"
				monoExecuter = go.AddComponent<MonoController>();
			}

			return monoExecuter;
		}
	}

	/// <summary>
	/// Allow outer to start coroutine
	/// </summary>
	/// <param name="routine"></param>
	public Coroutine StartCoroutine(IEnumerator routine)
	{
		return MonoExecuter.StartCoroutine(routine);
	}

	/// <summary>
	/// Allow outer to stop coroutine
	/// </summary>
	/// <param name="routine"></param>
	public void StopCoroutine(IEnumerator routine)
	{
		if (routine != null)
			MonoExecuter.StopCoroutine(routine);
	}
	public void StopCoroutine(Coroutine routine)
	{
		if (routine != null)
			MonoExecuter.StopCoroutine(routine);
	}
	public void StopAllCoroutines()
	{
		MonoExecuter.StopAllCoroutines();
	}


	/// <summary>
	/// Add FixedUpdate event.
	/// </summary>
	public void AddFixedUpdateListener(UnityAction call)
	{
		MonoExecuter.AddFixedUpdateListener(call);
	}
	/// <summary>
	/// Remove FixedUpdate event.
	/// </summary>
	public void RemoveFixedUpdateListener(UnityAction call)
	{
		MonoExecuter.RemoveFixedUpdateListener(call);
	}
	/// <summary>
	/// Remove all FixedUpdate event.
	/// </summary>
	public void RemoveAllFixedUpdateListeners()
	{
		MonoExecuter.RemoveAllFixedUpdateListeners();
	}

	/// <summary>
	/// Add Update event.
	/// </summary>
	public void AddUpdateListener(UnityAction call)
	{
		MonoExecuter.AddUpdateListener(call);
	}
	/// <summary>
	/// Remove Update event.
	/// </summary>
	public void RemoveUpdateListener(UnityAction call)
	{
		MonoExecuter.RemoveUpdateListener(call);
	}
	/// <summary>
	/// Remove all Update event.
	/// </summary>
	public void RemoveAllUpdateListeners()
	{
		MonoExecuter.RemoveAllUpdateListeners();
	}

	/// <summary>
	/// Add LateUpdate event.
	/// </summary>
	public void AddLateUpdateListener(UnityAction call)
	{
		MonoExecuter.AddLateUpdateListener(call);
	}
	/// <summary>
	/// Remove LateUpdate event.
	/// </summary>
	public void RemoveLateUpdateListener(UnityAction call)
	{
		MonoExecuter.RemoveLateUpdateListener(call);
	}
	/// <summary>
	/// Remove all LateUpdate event.
	/// </summary>
	public void RemoveAllLateUpdateListeners()
	{
		MonoExecuter.RemoveAllLateUpdateListeners();
	}

	/// <summary>
	/// Remove all Update¡¢FixedUpdate¡¢LateUpdate event.
	/// </summary>
	public void RemoveAllListeners()
	{
		MonoExecuter.RemoveAllListeners();
	}

	/// <summary>
	/// Executer script on MonoBehaviour. 
	/// Other scripts can use coroutine, FixedUpdate, Update, and LateUpdate methods through MonoManger through this class.
	/// </summary>
	public class MonoController : MonoBehaviour
	{

		event UnityAction updateEvent; // Events executed in the Update lifecycle method. Functions passed in as parameter

		event UnityAction fixedUpdaetEvent; // Events executed in the FixedUpdate lifecycle method.

		event UnityAction lateUpdateEvent; // Events executed in the LateUpdate lifecycle method.

		void Awake()
		{
			DontDestroyOnLoad(gameObject);
		}

		void FixedUpdate()
		{
			fixedUpdaetEvent?.Invoke();
		}

		void Update()
		{
			updateEvent?.Invoke();
		}

		void LateUpdate()
		{
			lateUpdateEvent?.Invoke();
		}

		public void AddFixedUpdateListener(UnityAction call)
		{
			fixedUpdaetEvent += call;
		}

		public void RemoveFixedUpdateListener(UnityAction call)
		{
			fixedUpdaetEvent -= call;
		}
		public void RemoveAllFixedUpdateListeners()
		{
			fixedUpdaetEvent = null;
		}

		public void AddUpdateListener(UnityAction call)
		{
			updateEvent += call;
		}

		public void RemoveUpdateListener(UnityAction call)
		{
			updateEvent -= call;
		}

		public void RemoveAllUpdateListeners()
		{
			updateEvent = null;
		}

		public void AddLateUpdateListener(UnityAction call)
		{
			lateUpdateEvent += call;
		}

		public void RemoveLateUpdateListener(UnityAction call)
		{
			lateUpdateEvent -= call;
		}

		public void RemoveAllLateUpdateListeners()
		{
			lateUpdateEvent = null;
		}
		public void RemoveAllListeners()
		{
			RemoveAllFixedUpdateListeners();
			RemoveAllUpdateListeners();
			RemoveAllUpdateListeners();
		}
	}

}
