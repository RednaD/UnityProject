using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observable : Activable
{
    public DialogueTreeEventSO  openingDialogue;
    public DialogueTreeSO       dialogueTree;

    public void Awake()
    {
        isInteractable = false;
    }

    public override void OnSelect()
    {
        openingDialogue.Raise(dialogueTree);
    }
}
