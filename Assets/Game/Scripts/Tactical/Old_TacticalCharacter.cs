using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Old_TacticalCharacter : TacticsMove            // PC on the board
{
    /*public bool                 isSelectable = false;
    public bool                 isSelected = false;
    public CharacterEventSO     onCharacterSelected;
    public CharacterEventSO     onCharacterUnselected;
    public SelectableEventSO    onSelection;
    public EventSO              onHasMoved;

    [SerializeField] private new Renderer renderer;
    public Material             defaultMaterial;
    public Material             hoveredMaterial;

    public StateMachine         stateMachine;
    public StateSO              moveState;
    public bool                 hasMoved;
    public bool                 hasAttacked;
    public bool                 hasUsedSpecial;

    public int                  life;
    public int                  lifeMax;
    public WeaponSO             weapon; 

    void Awake()
    {
        renderer = GetComponent<Renderer>();
        defaultMaterial = GetComponent<MeshRenderer>().material;
        Debug.Log(defaultMaterial);
        stateMachine = GameObject.Find("StateMachine").GetComponent<StateMachine>();
    }

    public void OnSelect()
    {
        Debug.Log(name + " is selected");
        SetHover(false);
        isSelected = true;
        onCharacterSelected.Raise(this);
        onSelection.Raise(this);
        //currentTile.FindReachableTiles(this);
    }

    public void OnDeselect()
    {
        //currentTile.Reset();
        if (stateMachine.currentState == moveState) return;
        Debug.Log(name + " is deselected");
        isSelected = false;
        onCharacterUnselected.Raise(this);
        onSelection.Raise(null);
    }

    public bool CheckIfSelectable()
    {
        // TODO if (!isSelectable) play error sound
        return isSelectable ^ isSelected;
    }

    public void SetHover(bool state)
    {
        if (!isSelected)
        {
            if (state) renderer.material = hoveredMaterial; // TODO StartAnimation
            else renderer.material = defaultMaterial;
            //else ResetMaterial(); // TODO StopAnimation
        }
    }

    public void MoveToTile(TacticalTile tile)
    {
        if (!isSelected) return;
        Debug.Log(name + " is moving");
        SetToTile(tile);
        onHasMoved.Raise();
        hasMoved = true;
        isSelectable = false;
        OnDeselect();
    }

    public void SetToTile(TacticalTile tile)
    {
        currentTile = tile;
        transform.position = tile.CharacterPosNode.transform.position;
    }

    public void Reset()
    {
        isSelectable = true;
        isSelected = false;
        hasMoved = false;
        hasAttacked = false;
        hasUsedSpecial = false;
    }*/
}
