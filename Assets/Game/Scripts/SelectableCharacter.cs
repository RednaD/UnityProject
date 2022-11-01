using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectableCharacter : Selectable
{
    [Header ("Selection")]
    public CharacterEventSO     onCharacterSelected;
    public CharacterEventSO     onCharacterUnselected;

    // EUH...
    public StateSO              moveState;
    public TacticalCharacter    character;

    void Awake()
    {
        character = GetComponent<TacticalCharacter>();
        //Debug.Log("Hi my name is mayeb " + character.name);
    }

    public override void SetHover(bool state)       // TODO put in class instead of override?
    {
        if (!isSelected)
        {
            if (state) GetComponent<Renderer>().material = hoveredMaterial; // TODO StartAnimation
            else GetComponent<Renderer>().material = defaultMaterial;
            //else ResetMaterial(); // TODO StopAnimation
        }
    }
}
