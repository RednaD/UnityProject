using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IMovementBehaviour : MonoBehaviour
{
    public float    posX;
    public float    posZ;

    public abstract void Reset();

    public abstract void SetToTile(TacticalTile tile);
}

