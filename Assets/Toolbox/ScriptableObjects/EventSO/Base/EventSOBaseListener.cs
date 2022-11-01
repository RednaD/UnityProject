using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class EventSOBaseListener<T, E, UER> : MonoBehaviour,
            IEventSOListener<T> where E : EventSOBase<T> where UER : UnityEvent<T> // T = Type, E = Event, UER = Unity Event Response
{
    [SerializeField] E eventE;
    public E EventSO { get { return eventE; } set { eventE = value; } }

    [SerializeField] private UER unityEventResponse;

    private void OnEnable()
    {
        if (unityEventResponse == null) { return; }

        EventSO.Register(this);
    }

    private void OnDisable()
    {
        if (unityEventResponse == null) { return; }

        EventSO.Unregister(this);
    }

    public void OnEventRaised(T item)
    {
        if (unityEventResponse != null)
        {
            unityEventResponse.Invoke(item);
        }
    }
}
