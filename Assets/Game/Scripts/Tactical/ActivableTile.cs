using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ActivableTile : Activable
{
    public TacticalTileEventSO  onTileSelected;

    public StateSO              moveState;
    public TacticalTile         tile;

    void Awake()
    {
        tile = GetComponent<TacticalTile>();
    }

    // SELECTION BEHAVIOUR
    public override void OnSelect()
    {
        Debug.Log(name + " is selected");
        if (stateMachine.v == moveState)
        {
            onTileSelected.Raise(tile); // TODO Move character
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
        /*if (!isSelected)
        {
            if (state) renderer.material.color = Color.yellow; // TODO StartAnimation
            else renderer.material.color = Color.green;
            //else ResetMaterial(); // TODO StopAnimation
        }*/
        if (state) GetComponent<Renderer>().material.color = Color.yellow; // TODO StartAnimation
        else if (isInteractable) GetComponent<Renderer>().material.color = Color.green;
        else ResetState();
    }
}
