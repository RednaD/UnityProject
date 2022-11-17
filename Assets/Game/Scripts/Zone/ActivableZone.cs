using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivableZone : MonoBehaviour, Zone
{
    public Activable interactable;

    public void OnTriggerEnter(Collider body)
    {
        if (!body.GetComponent<ControllableCharacter>()) return;
        interactable.SetInteractable(true);
    }

    public void OnTriggerExit(Collider body)
    {
        if (!body.GetComponent<ControllableCharacter>()) return;
        interactable.SetInteractable(false);
        interactable.SetHover(false);
    }
}
