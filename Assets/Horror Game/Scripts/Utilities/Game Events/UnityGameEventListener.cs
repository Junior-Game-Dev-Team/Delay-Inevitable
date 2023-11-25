using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public class UnityGameEventListener : MonoBehaviour, IGameEventListener
{
    [SerializeField] private List<GameEventList> gameEventList = new List<GameEventList>();

    private void OnEnable()
    {
        for(int i = gameEventList.Count - 1; i >= 0; i--) 
        {
            if (gameEventList[i].events != null)
                gameEventList[i].events.RegisterListener(this);
        }
    }

    private void OnDisable()
    {
        for (int i = gameEventList.Count - 1; i >= 0; i--)
        {
            if (gameEventList[i].events != null)
                gameEventList[i].events.RegisterListener(this);
        }
    }

    public void OnEventRaised()
    {
        for (int i = gameEventList.Count - 1; i >= 0; i--)
        {
            if (gameEventList[i].events != null)
            {
                gameEventList[i].responses?.Invoke();
            }
        }
    }

    public void OnEventRaised(bool statement)
    {
        for (int i = gameEventList.Count - 1; i >= 0; i--)
        {
            if (gameEventList[i].events != null)
            {
                gameEventList[i].b_responses?.Invoke(statement);
            }
        }
    }
}

[System.Serializable]
public struct GameEventList
{
    public string name;
    [Tooltip("Event to register with")]
    public GameEvent @events;
    [Tooltip("Unity Event to perform when raised")]
    public UnityEvent responses;
    public BoolUnityEvent b_responses;
}

[System.Serializable]
public class BoolUnityEvent : UnityEvent<bool> 
{
}