using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameEvent", menuName = "Events/Game Event")]
public class GameEvent : ScriptableObject
{
    protected readonly List<IGameEventListener> eventListeners = new List<IGameEventListener>();

    public virtual void Raise() 
    {
        for (int i = eventListeners.Count - 1; i >= 0; i--) 
        {
            eventListeners[i].OnEventRaised();
        }
    }

    public virtual void RaiseBool(bool statement)
    {
        for (int i = eventListeners.Count - 1; i >= 0; i--)
        {
            eventListeners[i].OnEventRaised(statement);
        }
    }

    public virtual void RegisterListener(IGameEventListener listener) 
    {
        if (!eventListeners.Contains(listener))
            eventListeners.Add(listener);
    }

    public virtual void UnRegisterListener(IGameEventListener listener) 
    {
        if (eventListeners.Contains(listener))
            eventListeners.Remove(listener);
    }
}
