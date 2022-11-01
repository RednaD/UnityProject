using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Activable : MonoBehaviour, Interactable
{
    //public bool isSelectable;
    public bool                             isActive;

    public StateVariable                    stateMachine;
    public StateSO                          allowedStates;        // TODO list of state where it can interact

    // Interactable
    public bool                             isInteractable;
    public bool                             defaultInteractableState;

    [Header ("Render")]
    [SerializeField] private new Renderer   renderer;
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
        Debug.Log("Default OnSelect");
        isActive = true;
    }

    public virtual void OnDeselect()
    {
        isActive = false;
    }

    public void TryInteract()
    {
        if (!isInteractable || allowedStates != stateMachine.v) return;       // TODO allowedStates.Contains(stateMachine)
        OnSelect();
    }
    
    public void SetState(bool state)
    {
        isInteractable = state;
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

    /*public bool CheckIfInteractable()
    {
        // TODO if (!isSelectable) play error sound
        return isSelectable ^ isSelected;
    }*/
}
