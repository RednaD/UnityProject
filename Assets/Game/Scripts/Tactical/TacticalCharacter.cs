using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TacticalCharacter : SelectableCharacter           // All Playables on the board (party)
{
    [Header ("Tactical Character")]
    public EventSO              onHasMoved;

    public int          life;
    public int          lifeMax;
    public WeaponSO     weapon;
    public int          move;
    public bool         canJump;

    public float        posX;
    public float        posZ;

    public bool         hasMoved;
    public bool         hasAttacked;
    public bool         hasUsedSpecial;

    void Awake()
    {
    }

    // SELECTION BEHAVIOUR
    public override void OnSelect()
    {
        Debug.Log("Good OnSelect");
        Debug.Log(name + " is selected");
        SetHover(false);
        isSelected = true;
        onCharacterSelected.Raise(this as TacticalCharacter);
        //onSelection.Raise(this);
        //currentTile.FindReachableTiles(this);
    }

    public override void OnDeselect()           // TODO Coroutine !!!!!!!!!!!!!!!!!!!!!!!!!!
    {
        //Debug.Log("isSelectable = " + isSelectable);
        //if (stateMachine.v == moveState) return;
        Debug.Log(name + " is deselected");
        isSelected = false;
        onCharacterUnselected.Raise(character);
        //onSelection.Raise(null);
    }

    public void MoveToTile(TacticalTile tile)       // TODO COROUTINE !!
    {
        Debug.Log("Meh");
        if (!isSelected) return;
        Debug.Log(name + " is moving");
        SetToTile(tile);
        onHasMoved.Raise();
        hasMoved = true;
        isInteractable = false;
        Debug.Log("is about to be unselectable = " + isInteractable);
        OnDeselect();
    }

    public void SetToTile(TacticalTile tile)
    {
        transform.position = tile.CharacterPosNode.transform.position;
        posX = tile.posGridX;
        posZ = tile.posGridZ;
    }

    public void Reset()
    {
        ResetState();
        hasMoved = false;
        hasAttacked = false;
        hasUsedSpecial = false;
    }
}
