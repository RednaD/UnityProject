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
        if (equipedObject != null) equipedObject.TryInteract();
    }

    public void DealDamage(TacticalNPC target)
    {
        Debug.Log(name + " attacks " + target.name);
    }
}
