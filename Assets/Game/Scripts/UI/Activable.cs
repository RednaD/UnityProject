using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Activable : MonoBehaviour, Interactable
{
    //public bool isSelectable;
    public bool                             isActive;

    public StateVariable                    stateMachine;
    public List<StateSO>                    allowedStates;

    // Interactable
    public bool                             isInteractable;
    public bool                             defaultInteractableState;

    [Header ("Render")]
    private new Renderer                    renderer;
    public Material                         defaultMaterial;
    public Material                         hoveredMaterial;

    void Awake()
    {
        renderer = GetComponent<Renderer>();
        defaultMaterial = GetComponent<MeshRenderer>().material;
        isInteractable = defaultInteractableState;
    }

    // SELECTION BEHAVIOUR
    public virtual void OnSelect()
    {
        Debug.Log("Default OnSelect");
        isActive = true;
    }

    public virtual void OnDeselect()
    {
        isActive = false;
    }

    public void TryInteract()
    {
        if (!isInteractable || !allowedStates.Contains(stateMachine.v)) return;
        OnSelect();
    }
    
    public void SetInteractable(bool state)
    {
        isInteractable = state;
    }

    public void SetState(bool state)
    {
        isActive = state;
    }

    public bool GetState()
    {
        return isActive;
    }
    
    public void ResetState()
    {
        isInteractable = defaultInteractableState;
        isActive = false;
    }

    public bool CheckIfInteractable()
    {
        return isInteractable;
    }

    public virtual void SetHover(bool state)       // TODO put in class instead of override?
    {
        if (!isActive)
        {
            if (state) renderer.material = hoveredMaterial; // TODO StartAnimation
            else renderer.material = defaultMaterial;
            //else ResetMaterial(); // TODO StopAnimation
        }
    }
}
