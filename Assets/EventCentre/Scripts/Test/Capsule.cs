using Mono.Cecil.Cil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Capsule Artist
/// </summary>
public class Capsule : MonoBehaviour
{

    void Awake()
    {
        EventCenterManager.Instance.AddListener(E_EventCommand.Work, Draw);

        EventCenterManager.Instance.AddListener(E_EventCommand.Fire, () => {
            Debug.Log("Artwork on fire!");
        });

        EventCenterManager.Instance.AddListener<int>(E_EventCommand.LevelUp, LevelUp);

    }


    public void Draw()
    {
        transform.Rotate(Vector3.forward, 5f);
        Debug.Log("I am an artist, I am drawing!");
    }

    public void LevelUp(int a)
    {
        Debug.Log($"I am an artist, I leveled up: {a + 2}");
    }


    void OnDestroy()
    {
        EventCenterManager.Instance.RemoveListener(E_EventCommand.Work, Draw);

        EventCenterManager.Instance.RemoveListener(E_EventCommand.Fire, () => {
            Debug.Log("Artwork on fire!");

        });

        EventCenterManager.Instance.RemoveListener<int>(E_EventCommand.LevelUp, LevelUp);

    }

}
