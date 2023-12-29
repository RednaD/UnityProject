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
        SetSelectionState(chara == this);
        //SetState(chara == this);
        //SetInteractable(chara != this && actionsLeft.Count != 0);
    }


    public void SetSelectionState(bool newSelectionState)
    {
        SetState(newSelectionState);
        SetInteractable(!newSelectionState && actionsLeft.Count != 0);
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
        tile.isOccupied = true; // ???
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

// TODO ce serait plutôt au perso de calculer les dommages car il a accès à toutes les infos et pas l'arme
// TODO vérifier avant qui attaque
    public void DealDamage(TacticalNPC target)
    {
        if (!GetState()) return;
        Debug.Log(name + " attacks " + target.name);
        Debug.Log(target.name + " a " + target.life + " de vie");
        Debug.Log(weapon.name);
        Debug.Log(weapon.name + " a " + weapon.Power + " d'attaque");
        //weapon.ComputeDamages();
        target.life -= weapon.Power;
        Debug.Log(target.name + " a " + target.life + " de vie");
        if (target.life <= 0)
            target.Dies();
        Debug.Log(name + " actionsLeft " + actionsLeft);
        actionsLeft.Remove(tacticalActionSet.attacking);
        Debug.Log(name + " actionsLeft " + actionsLeft);
        onActionEnded.Raise();
    }

    /*public void CheckActions()
    {
        if (actionsDone.Count == actionSet.Count) return;
        isInteractable = false;
        OnDeselect();
    }*/
}
