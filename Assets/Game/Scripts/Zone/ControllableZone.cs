using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllableZone : MonoBehaviour, Zone
{
    public Controllable interactable;

    public void OnTriggerEnter(Collider body)
    {
        if (!body.GetComponent<ControllableCharacter>()) return;
        interactable.SetInteractable(true);
    }

    public void OnTriggerExit(Collider body)
    {
        if (!body.GetComponent<ControllableCharacter>()) return;
        interactable.SetInteractable(false);
    }
}
