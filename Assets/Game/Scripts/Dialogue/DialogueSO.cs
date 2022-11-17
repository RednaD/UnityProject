using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Dial_", menuName = "Dialogue/DialogueSO")]
public class DialogueSO : EnumSO
{
    public Sprite               sprite;
    public string               content;

    public EnumSO               condition;
    public ConditionSO          choice;
    public EventSO              eventToCall;
    public List<DialogueOption> options;
    public List<DialogueSO>     nextLine;

    public DialogueSO GetNextLine(List<EnumSO> playerChoices)
    {
        DialogueSO defaultDialogue = null;
        foreach (DialogueSO dialogue in nextLine)
        {
            if (dialogue.condition == null && defaultDialogue == null) defaultDialogue = dialogue;
            if (playerChoices.Contains(dialogue.condition)) return dialogue;
        }
        return defaultDialogue;
    }
}