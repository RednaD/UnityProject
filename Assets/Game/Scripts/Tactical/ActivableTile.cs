using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ActivableTile : Activable
{
    public TacticalTileEventSO  onTileSelected;

    public TacticalTile         tile;

    void Awake()
    {
        tile = GetComponent<TacticalTile>();
    }

    // SELECTION BEHAVIOUR
    public override void OnSelect()
    {
        Debug.Log(name + " is selected");
        if (allowedStates.Contains(stateMachine.v))
        {
            onTileSelected.Raise(tile);
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
        if (state) GetComponent<Renderer>().material.color = Color.yellow; // TODO StartAnimation
        else if (isInteractable) GetComponent<Renderer>().material.color = Color.green;
        else ResetState();
    }
}
