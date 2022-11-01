using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TacticsMove : MonoBehaviour     // Any entity on the board, PC or NPC
{
    List<TacticalTile>      reachableTiles = new List<TacticalTile>();
    GameObject[]            tiles;
    public int              move;
    public bool             hasJump;

    Stack<TacticalTile>     path = new Stack<TacticalTile>();
    public TacticalTile     currentTile;


    private void Init()
    {
    }
}
