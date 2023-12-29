using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Interactable              // GO you can hover or click on
{
    public bool CheckIfInteractable();
    public void SetHover(bool state);
    public void TryInteract(EnumSO interactionType);  //TODO with an interactionType en paramètre
    public void SetInteractable(bool state);
    public void SetState(bool state);
}
