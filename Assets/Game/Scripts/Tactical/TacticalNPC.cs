using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TacticalNPC : ActivableNPC           // All Playables on the board (party)
{
    [Header ("Tactical")]
    public CharacterEventSO     onCharacterMoving;
    public CharacterEventSO     onCharacterAttacking;
    public CharacterEventSO     onCharacterUsingSpecial;

    [Header ("Stats")]
    public int                  life;
    public int                  lifeMax;
    public WeaponSO             weapon;
    public int                  move;
    public bool                 canJump;

    public float                posX;
    public float                posZ;
    public int                  posY;

    public bool                 isTargetable = false;
    public bool                 defaultTargetable;
    public bool                 isAlly = false;

    public GameObject           CharacterPosNode;
    public ITileType            type;

    void Start()
    {
        type = GetComponent<ITileType>();
        defaultTargetable = isTargetable;
    }

    public void GetContextMaterial()                                  // Old?
    {
        if (!isTargetable) return;
        if (CheckIfInteractable()) GetComponent<Renderer>().material.color = Color.green;   // TODO: replace with palette
        else ResetMaterial();
    }

    public void Reset()
    {
        ResetState();
        isTargetable = defaultTargetable;
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
            if (GetComponent<Renderer>() != null) GetComponent<Renderer>().material = defaultMaterial;   // TODO: replace with palette
        }
    }

    public interface ITileType
    {
        Material GetMaterial();
    }

    public void MoveToTile(TacticalTile tile)       // TODO COROUTINE!!
    {
        if (!GetState()) return;
        Debug.Log(name + " is moving");
        SetToTile(tile);
        isInteractable = false;
        OnDeselect();
    }

    public void SetToTile(TacticalTile tile)
    {
        transform.position = tile.CharacterPosNode.transform.position;
        posX = tile.posGridX;
        posZ = tile.posGridZ;
    }
}
