using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Controllable : MonoBehaviour, Interactable
{
    //public bool isControllable;
    public bool                             isSelected;
    public ControllableEventSO              onSelection;

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
    }

    // SELECTION BEHAVIOUR
    public virtual void OnSelect()
    {
        Debug.Log("Please don't show that message D: ");
        isSelected = true;
        onSelection.Raise(this);
    }

    public virtual void OnDeselect()
    {
        isSelected = false;
        onSelection.Raise(null);
    }

    public void TryInteract(EnumSO interactionType)
    {
        Debug.Log("In Controllable, on TryInteract");
        Debug.Log("EnumSO = " + interactionType);
        if (!isInteractable || !allowedStates.Contains(stateMachine.v)) return;
        if (interactionType = InteractionType.selection) OnSelect();
        //if (interactionType = InteractionType.action) OnAct();
    }
    
    public void SetInteractable(bool state)
    {
        isInteractable = state;
    }

    public void SetState(bool state)
    {
        isSelected = state;
    }

    public bool GetState()
    {
        return isSelected;
    }
    
    public void ResetState()
    {
        isInteractable = defaultInteractableState;
        OnDeselect();
        //isSelected = false;
    }

    public bool CheckIfInteractable()
    {
        return isInteractable;
    }

    public virtual void SetHover(bool state)       // TODO put in class instead of override?
    {
        if (!GetState())
        {
            if (state) renderer.material = hoveredMaterial; // TODO StartAnimation
            else renderer.material = defaultMaterial;
            //else ResetMaterial(); // TODO StopAnimation
        }
    }
}
