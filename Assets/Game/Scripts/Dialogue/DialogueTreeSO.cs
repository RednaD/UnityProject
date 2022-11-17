using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DialTree_", menuName = "Dialogue/DialogueTreeSO")]
public class DialogueTreeSO : ScriptableObject
{
    public List<DialogueSO>     dialogues;
    public DialogueSO           replayLine;     // to replace after last dialogue ended


    public DialogueSO GetDialogue(List<EnumSO> playerChoices)
    {
        if (dialogues == null) return null;
        foreach (DialogueSO dialogue in dialogues)
        {
            if (dialogue == null) return null;
            if (!playerChoices.Contains(dialogue as EnumSO) && (dialogue.condition == null || playerChoices.Contains(dialogue.condition)))
                return dialogue;
        }
        return replayLine;
    }
}

    //  Liste dialogues par defaut au hasard
    // Liste dialogues avec conditions

// On parle à Carlos sans avoir parlé aux autres
// Onparle en ayant parlé à 1 autre
// Aux deux autres