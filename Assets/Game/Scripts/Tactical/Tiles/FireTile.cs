using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTile : MonoBehaviour, ITileType
{
    public Material defaultMaterial;   // TODO: remove parce que c'est de la merde

    public Material GetMaterial()
    {
        return defaultMaterial;
    }
}
