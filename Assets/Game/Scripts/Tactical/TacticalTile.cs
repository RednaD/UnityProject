using System.Collections.Generic;
using UnityEngine;

public class TacticalTile : ActivableTile
{
    public bool                 isTarget = false;   //todo: ENUM?
    public bool                 isWalkable = false;
    public bool                 defaultWalkable;
    public bool                 isOccupied = false;

    public bool                 isProcessed;        // was checked by grid
    public TacticalTile         parent;
    public int                  distance = 0;

    public GameObject           CharacterPosNode;
    public ITileType            type;
    //public List<TacticalTile>   neighborsList;
    //public TacticalGridSO       grid;
    
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
        //if (isTarget) renderer.material.color = Color.yellow;   // TODO: replace with palette
        if (!isWalkable) return;
        if (CheckIfInteractable()) GetComponent<Renderer>().material.color = Color.green;   // TODO: replace with palette
        else ResetMaterial();
    }

    public void FindReachableTiles(TacticalCharacter character, TacticalTile[,] grid)
    {
        int movesLeft = character.move;
        isWalkable = false;
        //isProcessed = true;

        FindRecurcively(character, movesLeft, grid, grid[posGridZ, posGridX], posGridX + 1, posGridZ);
        FindRecurcively(character, movesLeft, grid, grid[posGridZ, posGridX], posGridX - 1, posGridZ);
        FindRecurcively(character, movesLeft, grid, grid[posGridZ, posGridX], posGridX, posGridZ + 1);
        FindRecurcively(character, movesLeft, grid, grid[posGridZ, posGridX], posGridX, posGridZ - 1);
    }

    public void FindRecurcively(TacticalCharacter character, int movesLeft, TacticalTile[,] grid, TacticalTile lastTile, int x, int z)
    {
        if (movesLeft <= 0 || x < 0 || x >= grid.GetLength(1) || z < 0 || z >= grid.GetLength(0)) return;
        //grid[z, x].isProcessed = true;
        int test = (character.canJump ? 1 : 0) + 1;
        if (grid[z, x].isWalkable && Mathf.Abs(lastTile.posGridY - grid[z, x].posGridY) <= test)
        {
            grid[z, x].SetState(true);
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
        //if (selection == null) selection = GetComponent<Selectable>();
        //if (selection == null) Debug.Log("Ousp!");
        ResetState();
        isProcessed = false;
        isWalkable = defaultWalkable;

        ResetMaterial();
        //Debug.Log("Bah alors?");
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

        /*if (currentTile.v == this) Reset();
        else if (!isSelectable) return;                      // TODO play error sound?
        else
        {
            if (currentTile.v != null) currentTile.v.Reset();
            currentTile.v = this;
            isSelected = true;
            renderer.material.color = Color.blue;   // TODO: replace with palette
        }*/


    /*public void FindNeighbors(float jumpHeight)
    {
        Reset();
        CheckTile(Vector3.forward, jumpHeight);
        CheckTile(-Vector3.forward, jumpHeight);
        CheckTile(Vector3.right, jumpHeight);
        CheckTile(-Vector3.right, jumpHeight);
    }

    public void CheckTile(Vector3 direction, float jumpHeight)          // TODO replace with coordinates (mais quelle horreur...)
    {
        RaycastHit[] hits;
        hits = Physics.RaycastAll(transform.position, direction, 1f + jumpHeight);
        foreach (RaycastHit hit in hits)
        {
            TacticalTile tile = hit.transform.GetComponent<TacticalTile>();
            if (tile != null && tile.isWalkable && !isOccupied)
            {
                Debug.Log(tile);
                tile.renderer.material.color = Color.green;
                neighborsList.Add(tile);
            }
        }

        Vector3 halfExtents = new Vector3(0.25f, (1 + jumpHeight) / 2.0f, 0.25f);
        Collider[] colliders = Physics.OverlapBox(transform.position + direction, halfExtents);

        foreach (Collider item in colliders)
        {
            TacticalTile tile = item.GetComponent<TacticalTile>();
            if (tile != null && tile.isWalkable && !isOccupied)
            {
                Debug.Log(tile);
                //tile.renderer.material.color = Color.green;
                neighborsList.Add(tile);
            }
        }
        
    }*/