using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllableCharacter : Controllable
{
    public CollectionVariable   inventory;
    public Activable            equipedObject;

    [Header ("Selection")]
    public CharacterEventSO     onCharacterSelected;
    public CharacterEventSO     onCharacterUnselected;

    // EUH...
    public StateSO              moveState;
    public TacticalCharacter    character;

    [Header ("Stats")]
    public int                  life;
    public int                  lifeMax;
    public WeaponSO             weapon;
    public int                  move;
    public bool                 canJump;

    void Awake()
    {
        character = GetComponent<TacticalCharacter>();
        //Debug.Log("Hi my name is mayeb " + character.name);
    }

    public override void SetHover(bool state)       // TODO put in class instead of override?
    {
        if (!GetState())
        {
            if (state) GetComponent<Renderer>().material = hoveredMaterial; // TODO StartAnimation
            else GetComponent<Renderer>().material = defaultMaterial;
            //else ResetMaterial(); // TODO StopAnimation
        }
    }

    public void AddToInventory(CollectableSO item)
    {
        inventory.v.Add(item);
    }

    public void UseObject()
    {
        if (equipedObject != null) equipedObject.TryInteract(InteractionType.action);
    }

// TODO ce serait plutôt au perso de calculer les dommages car il a accès à toutes les infos et pas l'arme
// TODO vérifier avant qui attaque
    /*public void DealDamage(TacticalNPC target)
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
        Debug.Log(name + " actionsLeft " + character.actionsLeft);
        character.actionsLeft.Remove(character.tacticalActionSet.moving);
        Debug.Log(name + " actionsLeft " + character.actionsLeft);
        character.onActionEnded.Raise();
    }*/
}
