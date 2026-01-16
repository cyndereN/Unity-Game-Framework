using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Sphere programmer
/// </summary>
public class Sphere : MonoBehaviour
{
    void Awake()
    {
        EventCenterManager.Instance.AddListener(E_EventCommand.Work, Code);

        EventCenterManager.Instance.AddListener(E_EventCommand.Fire, () => {
            Debug.Log("I am a programmer! I am Immune to fire！");
        });

        EventCenterManager.Instance.AddListener<int>(E_EventCommand.LevelUp, LevelUp);

    }



    public void Code()
    {
        transform.localScale += new Vector3(1, 0, 0);
        Debug.Log("I am a programmer, I am writing codes！");
    }

    public void LevelUp(int a)
    {
        Debug.Log($"I am a programmer, I leveled up: {a+1}");
    }


    void OnDestroy()
    {
        EventCenterManager.Instance.RemoveListener(E_EventCommand.Work, Code);

        EventCenterManager.Instance.RemoveListener(E_EventCommand.Fire, () => {
			Debug.Log("I am a programmer! I am Immune to fire！");
		});

        EventCenterManager.Instance.RemoveListener<int>(E_EventCommand.LevelUp, LevelUp);
    }

}
