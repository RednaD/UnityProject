using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Option_", menuName = "Dialogue/DialogueOptionSO")]
public class DialogueOption : EnumSO
{
    public string           text;
    public DialogueSO       nextLine;
}
