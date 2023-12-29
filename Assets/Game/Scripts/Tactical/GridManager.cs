using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public CharacterEventSO     onShowCharacterActions;
    //public CharacterEventSO     onFirstCharacterSelected;
    //public InteractionTypeEnum  InteractionType;

    public TacticalTile[,]      grid;
    public TacticalTile         emptyTile;
    public PartySO_GO           partyPool;
    public PartySO_TC           party;
    public PartySO_GO           enemiesPool;
    public GroupeSO_TNPC        enemies;    // TODO make it so only a few are selected by random
    public List<TacticalTile>   startPosParty;
    public List<TacticalTile>   startPosEnemies;

    // TODO ajouter case apparition persos dans niveau (apparition puis va à case assignée au-dessus)

    float minX;
    float minZ;
    int lenZ;
    int lenX;

    //public IMovementBehaviour   movementBehaviour;

    //public TacticalCharacter        player; // TODO instanciate prefabs later

    //TODO ajouter des poin 'characters' qu'on place sur la map à l'endroit où on veut les voir arriver
    //public void Awake()
    public void Init()
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
                if (grid[i, j] == null)
                {
                    grid[i, j] = emptyTile;
                    grid[i, j].isWalkable = false;
                }
            }
        }
    }

    public TacticalTile GetTile(float x, float z)
    {
        return grid[Mathf.FloorToInt(z), Mathf.FloorToInt(x)];
    }

    public void OnResetGrid()
    {
        //StartCoroutine(Reset());
    }

    public IEnumerator Reset(PartySO_TC party, GroupeSO_TNPC enemies)     // TODO rename Reset
    {
        for (int i = 0; i < lenZ; i++)
        {
            for (int j = 0; j < lenX; j++)
            {
                if (grid[i, j] != null) grid[i, j].Reset();
            }
        }
        foreach(TacticalCharacter character in party.v) GetTile(character.posX, character.posZ).isOccupied = true;
        foreach(TacticalNPC npc in enemies.v)
        {
            npc.Reset();
            GetTile(npc.posX, npc.posZ).isOccupied = true;
        }
        Debug.Log("Grid reseted");
        yield return null;
    }
}
