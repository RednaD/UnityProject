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
    public InteractionTypeEnum              InteractionType;
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

    public void TryInteract(EnumSO interactionType)
    {
        Debug.Log("In Activable, on TryInteract");
        Debug.Log("EnumSO = " + interactionType);
        if (!isInteractable || (allowedStates.Count != 0 && !allowedStates.Contains(stateMachine.v))) return;
        if (interactionType == InteractionType.action) OnSelect();
        //if (interactionType == InteractionType.action) OnAct();
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
            if (state) GetComponent<Renderer>().material = hoveredMaterial; // TODO StartAnimation
            else GetComponent<Renderer>().material = defaultMaterial;
            //else ResetMaterial(); // TODO StopAnimation
        }
    }
}
