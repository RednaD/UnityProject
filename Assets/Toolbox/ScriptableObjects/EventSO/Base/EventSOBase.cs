using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EventSOBase<T> : ScriptableObject
{
    private readonly List<IEventSOListener<T>> listeners = new List<IEventSOListener<T>>();

    public void Raise(T item)
    {
        for(int i = listeners.Count - 1; i >= 0; i--)
        {
            listeners[i].OnEventRaised(item);
        }
    }

    public void Register(IEventSOListener<T> listener)
    {
        if (!listeners.Contains(listener))
        {
            listeners.Add(listener);
        }
    }
    
    public void Unregister(IEventSOListener<T> listener)
    {
        if (listeners.Contains(listener))
        {
            listeners.Add(listener);
        }
    }
}
