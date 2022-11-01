using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TacticalGridSO_", menuName = "VariableSO/TacticalGridSO")]
public class TacticalGridSO : ScriptableObject
{
    public List<TacticalTile> v;
}
