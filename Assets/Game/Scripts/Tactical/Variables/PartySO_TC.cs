using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "P_", menuName = "VariableSO/PartySO_TC")]
public class PartySO_TC : ScriptableObject
{
    public List <TacticalCharacter> v;

    public TacticalCharacter GetSelected()
    {
        foreach (TacticalCharacter character in v)
        {
            Debug.Log(character);
            if (character.isSelected) return character;
        }
        return null;
    }
}
