using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivableNPC : Activable
{
    [Header ("Selection")]
    public TacticalNPCEventSO   onNPCSelected;
    public TacticalNPCEventSO   onNPCDies;

    // EUH...
    public TacticalNPC          nPC;

    void Awake()
    {
        nPC = GetComponent<TacticalNPC>();
    }

    // SELECTION BEHAVIOUR
    public override void OnSelect()
    {
        Debug.Log(name + " is selected");
        if (allowedStates.Contains(stateMachine.v))
        {
            Debug.Log("Event de Activable est ici !! " + nPC);
            onNPCSelected.Raise(nPC); // TODO Move character
        }
        else
        {
            GetComponent<Renderer>().material.color = Color.blue;
            isActive = true;
        }
    }

    public override void OnDeselect()
    {
        Debug.Log(name + " is deselected");
        ResetState();
    }

    public override void SetHover(bool state)
    {
        if (state) GetComponent<Renderer>().material = hoveredMaterial; // TODO StartAnimation
        else GetComponent<Renderer>().material = defaultMaterial;
        //else if (isInteractable) GetComponent<Renderer>().material.color = Color.green;             // TODO type (ally, enemy...)
        //else ResetState();
    }

    public void Remove()
    {
        onNPCDies.Raise(nPC);
    }
}
