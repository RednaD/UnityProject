using System.Collections.Generic;
using UnityEngine;

public class TacticalTile : ActivableTile
{
    public bool                 isTarget = false;   //todo: ENUM?
    public bool                 isWalkable = false;
    public bool                 defaultWalkable;
    public bool                 isOccupied = false;

    public GameObject           CharacterPosNode;
    public ITileType            type;
    
    public int                  posGridX;
    public int                  posGridZ;
    public int                  posGridY;

    void Start()
    {
        type = GetComponent<ITileType>();
        defaultWalkable = isWalkable;
    }

    public void GetContextMaterial()                                  // Old?
    {
        if (!isWalkable) return;
        if (CheckIfInteractable()) GetComponent<Renderer>().material.color = Color.green;   // TODO: replace with palette
        else ResetMaterial();
    }

    public void FindReachableTiles(TacticalCharacter character, TacticalTile[,] grid)
    {
        int movesLeft = character.move;
        isWalkable = false;

        FindRecurcively(character, movesLeft, grid, grid[posGridZ, posGridX], posGridX + 1, posGridZ);
        FindRecurcively(character, movesLeft, grid, grid[posGridZ, posGridX], posGridX - 1, posGridZ);
        FindRecurcively(character, movesLeft, grid, grid[posGridZ, posGridX], posGridX, posGridZ + 1);
        FindRecurcively(character, movesLeft, grid, grid[posGridZ, posGridX], posGridX, posGridZ - 1);
    }

    public void FindRecurcively(TacticalCharacter character, int movesLeft, TacticalTile[,] grid, TacticalTile lastTile, int x, int z)
    {
        if (movesLeft <= 0 || x < 0 || x >= grid.GetLength(1) || z < 0 || z >= grid.GetLength(0)) return;
        int test = (character.canJump ? 1 : 0) + 1;
        if (grid[z, x].isWalkable && !grid[z, x].isOccupied && Mathf.Abs(lastTile.posGridY - grid[z, x].posGridY) <= test)
        {
            grid[z, x].SetInteractable(true);
            grid[z, x].GetContextMaterial();
        }
        if (grid[z, x].isWalkable || character.canJump)
        {
            movesLeft--;
            FindRecurcively(character, movesLeft, grid, grid[z, x], x + 1, z);
            FindRecurcively(character, movesLeft, grid, grid[z, x], x - 1, z);
            FindRecurcively(character, movesLeft, grid, grid[z, x], x, z + 1);
            FindRecurcively(character, movesLeft, grid, grid[z, x], x, z - 1);
        }
    }

    public void Reset()
    {
        ResetState();
        isWalkable = defaultWalkable;
        isOccupied = false;

        ResetMaterial();
    }

    public void ResetMaterial()
    {
        if (type != null)
        {
            GetComponent<Renderer>().material = type.GetMaterial();
        }
        else
        {
            if (GetComponent<Renderer>() != null) GetComponent<Renderer>().sharedMaterial.color = Color.white;   // TODO: replace with palette
        }
    }
}

public interface ITileType
{
    Material GetMaterial();
}
