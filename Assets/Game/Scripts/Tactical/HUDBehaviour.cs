using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUDBehaviour : MonoBehaviour
{
    public TextMeshProUGUI      _UT;
    public TacticalCharacter    activeCharacter;

    public void OnCharacterSelected(TacticalCharacter character)
    {
        activeCharacter = character;
    }
}
