using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Cube Designer Test Class
/// </summary>
public class Cube : MonoBehaviour
{

    void Awake()
    {
        EventCenterManager.Instance.AddListener(E_EventCommand.Work, Write);

        EventCenterManager.Instance.AddListener(E_EventCommand.Fire, () => {
            Debug.Log("Designer? So hot in here!");
        
        });

        EventCenterManager.Instance.AddListener<int>(E_EventCommand.LevelUp, LevelUp);
    }

        
    public void Write()
    {
        transform.position += Vector3.right;
        Debug.Log("I am a designer！");
    }

    public void LevelUp(int a)
    {
        Debug.Log($"I am a designer, level: {a}");
    }

    // Customized class or tuple to handle multiple params
    public void Show(MyInfo myInfo)
    {
        Debug.Log($"int {myInfo.a}, float {myInfo.b}, double {myInfo.c}");
    }

    void OnDestroy()
    {
        EventCenterManager.Instance.RemoveListener(E_EventCommand.Work, Write);

        EventCenterManager.Instance.RemoveListener(E_EventCommand.Fire, () => {
            Debug.Log("So hot in here!");

        });

        EventCenterManager.Instance.RemoveListener<int>(E_EventCommand.LevelUp, LevelUp);
    }
}
