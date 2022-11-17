using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Activable
{
    public List<CollectableSO>  inventory;
    public CollectableEventSO   addToInventoryEvent;

    public DialogueTreeEventSO  openingDialogue;
    public DialogueTreeSO       dialogueTree;

    public void Awake()
    {
        isInteractable = false;
    }

    public override void OnSelect()
    {
        openingDialogue.Raise(dialogueTree);                //envoyer le Tree 
        foreach (CollectableSO item in inventory)
        {
            addToInventoryEvent.Raise(item);
        }
        inventory.Clear();
    }
}
