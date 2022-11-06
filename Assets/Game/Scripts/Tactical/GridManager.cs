using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public CharacterEventSO     onShowCharacterActions;

    public TacticalTile[,]      grid;
    public TacticalTile         emptyTile;
    public PartySO_GO           partyGO;
    public PartySO_TC           party;
    public PartySO_GO           enemiesGO;
    public GroupeSO_TNPC        enemies;
    public List<TacticalTile>   startPosParty;
    public List<TacticalTile>   startPosEnemies;

    float minX;
    float minZ;
    int lenZ;
    int lenX;

    //public IMovementBehaviour   movementBehaviour;

    //public TacticalCharacter        player; // TODO instanciate prefabs later

    public void Awake()
    {
        TacticalTile[] mapToLoad = GameObject.FindObjectsOfType<TacticalTile>();
        minX = float.MaxValue;
        minZ = minX;
        float maxX = float.MinValue;
        float maxZ = maxX;
        Transform t;
        int i = 0;
        while (i < mapToLoad.Length)
        {
            t = mapToLoad[i].transform;

            if (t.position.x < minX) minX = t.position.x;
            if (t.position.x > maxX) maxX = t.position.x;
            if (t.position.z < minZ) minZ = t.position.z;
            if (t.position.z > maxZ) maxZ = t.position.z;
            
            i++;
        }
        int gridX = Mathf.FloorToInt(maxX - minX);
        int gridZ = Mathf.FloorToInt(maxZ - minZ);

        grid = new TacticalTile[gridZ + 1, gridX + 1];
        int x, z, y;
        i = 0;
        while (i < mapToLoad.Length)
        {
            x = Mathf.FloorToInt(mapToLoad[i].transform.position.x - minX);
            z = Mathf.FloorToInt(mapToLoad[i].transform.position.z - minZ);
            y = Mathf.FloorToInt(mapToLoad[i].transform.position.y);
            if (grid[z,x] != null) Debug.Log("Error: overlapping tiles at " + x + ", " + "z");
            else
            {
                grid[z,x] = mapToLoad[i];
                grid[z,x].posGridX = x;
                grid[z,x].posGridZ = z;
                grid[z,x].posGridY = y;
            }
            i++;
        }
        lenZ = grid.GetLength(0);
        lenX = grid.GetLength(1);
        for (i = 0; i < lenZ; i++)
        {
            for (int j = 0; j < lenX; j++)
            {
                //Debug.Log(grid[i, j]);
                if (grid[i, j] == null)
                {
                    grid[i, j] = emptyTile;
                    grid[i, j].isWalkable = false;
                }
            }
        }

        GameObject playerGO;
        TacticalCharacter playerTC;
        party.v.Clear();
        i = 0;
        while (i < partyGO.v.Count)
        {
            playerGO = Instantiate(partyGO.v[i]);
            playerTC = playerGO.GetComponent<TacticalCharacter>();
            //playerTC.move = new movementBehaviour;
            playerTC.SetToTile(startPosParty[i]);
            playerTC.Reset();
            party.v.Add(playerTC);
            i++;
        }

        GameObject enemyGO;
        TacticalNPC enemyTC;
        enemies.v.Clear();
        i = 0;
        while (i < enemiesGO.v.Count)
        {
            enemyGO = Instantiate(enemiesGO.v[i]);
            enemyTC = enemyGO.GetComponent<TacticalNPC>();
            enemyTC.SetToTile(startPosEnemies[i]);
            enemyTC.Reset();
            enemies.v.Add(enemyTC);
            i++;
        }
    }

    public void OnCharacterSelected(TacticalCharacter activeCharacter)
    {
        ResetGrid();
        //foreach(TacticalCharacter character in party.v) character.onSetSelection(activeCharacter);
        onShowCharacterActions.Raise(activeCharacter);
    }

    public void OnCharacterMoving(TacticalCharacter character)
    {
        ResetGrid();
        //if (character.hasMoved) return;
        GetTile(character.posX, character.posZ).FindReachableTiles(character, grid);
    }

    public void OnCharacterAttacking(TacticalCharacter character)
    {
        ResetGrid();
        //if (character.hasAttacked) return;
        character.FindReachableTargets(enemies);
    }

    public void OnCharacterUsingSpecial(TacticalCharacter character)
    {
        ResetGrid();
        //if (character.hasAttacked) return;
        //character.FindReachableTargets(enemies);
    }

    public TacticalTile GetTile(float x, float z)
    {
        return grid[Mathf.FloorToInt(z), Mathf.FloorToInt(x)];
    }

    public void OnNewTurn()
    {
        foreach(TacticalCharacter character in party.v) character.Reset();
        ResetGrid();
    }

    public void ResetGrid()
    {
        for (int i = 0; i < lenZ; i++)
        {
            for (int j = 0; j < lenX; j++)
            {
                if (grid[i, j] != null) grid[i, j].Reset();
            }
        }
        foreach(TacticalCharacter character in party.v) GetTile(character.posX, character.posZ).isOccupied = true;
        foreach(TacticalNPC npc in enemies.v) GetTile(npc.posX, npc.posZ).isOccupied = true;
    }
}
