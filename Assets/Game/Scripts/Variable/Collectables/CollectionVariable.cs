using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Collection", menuName = "VariableSO/CollectionVariable")]
public class CollectionVariable : ScriptableObject
{
    public List<CollectableSO> v;
}
