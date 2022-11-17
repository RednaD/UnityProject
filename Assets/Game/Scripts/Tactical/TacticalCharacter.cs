using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TacticalCharacter : ControllableCharacter           // All Playables on the board (party)
{
    [Header ("Tactical")]
    public EventSO              onActionEnded;
    public CharacterEventSO     onCharacterMoving;
    public CharacterEventSO     onCharacterAttacking;
    public CharacterEventSO     onCharacterUsingSpecial;
    public StateSO              currentMode;
    public TacticalEnum         tacticalActionSet;

    public float        posX;
    public float        posZ;
    public float        posY;

    [Header ("Variables")]
    public List<StateSO>    actionSet;
    public List<StateSO>    actionsLeft;

    // SELECTION BEHAVIOUR
    public override void OnSelect()
    {
        Debug.Log(name + " is selected");
        SetHover(false);
        GameObject[] characters = GameObject.FindGameObjectsWithTag("TacticalCharacter");
        foreach(var child in characters)
        {
            TacticalCharacter character = child.GetComponent<TacticalCharacter>();
            character.SetState(false);
            character.SetInteractable(actionsLeft.Count != 0);
        }
        SetState(true);
        SetInteractable(false);
        onCharacterSelected.Raise(this);
    }

    public override void OnDeselect()           // TODO Coroutine !!!!!!!!!!!!!!!!!!!!!!!!!!
    {
        //if (stateMachine.v == moveState) return;
        SetState(false);
        SetInteractable(actionsLeft.Count != 0);
        Debug.Log(name + " is deselected");
        onCharacterUnselected.Raise(character);
    }

    public void onSetSelection(TacticalCharacter chara)
    {
        SetState(chara == this);
        SetInteractable(chara != this && actionsLeft.Count != 0);
    }

    public void OnChangeMode(EnumSO newMode)
    {
        currentMode = newMode as StateSO;
        if (isSelected) HandleMode();
    }

    public void HandleMode()
    {
        if (currentMode == tacticalActionSet.moving) onCharacterMoving.Raise(this as TacticalCharacter);
        if (currentMode == tacticalActionSet.attacking) onCharacterAttacking.Raise(this as TacticalCharacter);
        if (currentMode == tacticalActionSet.usingSpecial) onCharacterUsingSpecial.Raise(this as TacticalCharacter);
    }

    public void FindReachableTargets(GroupeSO_TNPC nPC)
    {
        if (weapon == null) return;
        foreach(TacticalNPC npc in nPC.v)
        {
            if (Mathf.Abs(Mathf.Abs(posX) + Mathf.Abs(posZ) + Mathf.Abs(posY)
                    - Mathf.Abs(npc.posX) - Mathf.Abs(npc.posZ) - Mathf.Abs(npc.posY)) <= weapon.range)
            {
                npc.SetInteractable(true);
                npc.GetContextMaterial();
            }
        }
    }

    public void MoveToTile(TacticalTile tile)       // TODO COROUTINE !!
    {
        if (!GetState()) return;
        Debug.Log(name + " is moving");
        SetToTile(tile);
        actionsLeft.Remove(tacticalActionSet.moving);
        onActionEnded.Raise();
        //CheckActions();
    }

    public void SetToTile(TacticalTile tile)
    {
        transform.position = tile.CharacterPosNode.transform.position;
        posX = tile.posGridX;
        posZ = tile.posGridZ;
        posY = tile.posGridY;
    }

    public void Reset()
    {
        actionsLeft.Clear();
        foreach (StateSO state in actionSet) actionsLeft.Add(state);
        ResetState();
    }

    /*public void CheckActions()
    {
        if (actionsDone.Count == actionSet.Count) return;
        isInteractable = false;
        OnDeselect();
    }*/
}
