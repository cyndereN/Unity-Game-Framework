using UnityEngine;
using UnityEngine.SceneManagement;

public class Test : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
			// if this line is not called then it's not created, since it is the only ref to Instance
			SingletonComponent_Test.Instance.Show();
        }

		if (Input.GetKeyDown(KeyCode.H))
		{
			MyUIManager.Instance.Show();
			MyUIManager.Instance.Hide();
		}

		if (Input.GetKeyDown(KeyCode.W))
		{
            SceneManager.LoadScene("SingletonTestScene_2");
		}
	}

	private void OnDestroy()
	{
		if (MyUIManager.IsCreated) 
		{
			MyUIManager.Instance.Show();
		}

		if (SingletonComponent_Test.IsCreated)
		{
			SingletonComponent_Test.Instance.Show();
		}
	}
}
