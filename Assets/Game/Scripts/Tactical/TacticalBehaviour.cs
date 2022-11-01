using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TacticalBehaviour// : IMovementBehaviour      //Rename TacticalMovement
{
    /*public EventSO              onHasMoved;

    public StateMachine         stateMachine;
    public StateSO              moveState;
    public bool                 hasMoved;
    public bool                 hasAttacked;
    public bool                 hasUsedSpecial;

    //public TacticalTile         currentTile;
    List<TacticalTile>          reachableTiles = new List<TacticalTile>();
    GameObject[]                tiles;
    public int                  move;
    public bool                 hasJump;

    //public ISelectable          selection;

    void Awake()
    {
        stateMachine = GameObject.Find("StateMachine").GetComponent<StateMachine>();
        selection = GetComponent<ISelectable>();
    }

    public void Move(Vector3 position)
    {
        posX = position.x;
        posZ = position.z;
    }

    public void MoveToTile(TacticalTile tile)
    {
        if (!selection.GetSelectState()) return;
        SetToTile(tile);
        onHasMoved.Raise();
        hasMoved = true;
        selection.SetSelectableState(false);
        selection.OnDeselect();
    }

    public override void SetToTile(TacticalTile tile)
    {
        //currentTile = tile;
        transform.position = tile.CharacterPosNode.transform.position;
    }

    public override void Reset()
    {
        hasMoved = false;
        hasAttacked = false;
        hasUsedSpecial = false;
    }*/
}
