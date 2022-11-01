using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public StateVariable    currentState;
    public StateSO          defaultSate;

    public void Awake()
    {
        SetToState(defaultSate);
    }

    public void SetToState(StateSO state)
    {
        currentState.v = state;
    }
}
