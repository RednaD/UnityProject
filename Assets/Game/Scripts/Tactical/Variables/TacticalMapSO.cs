using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TM_", menuName = "VariableSO/TacticalMap0")]
public class TacticalMapSO : ScriptableObject
{
    public List<TacticalTile>   startPosGroup;
    //public List<Vector2> startPosEnnemies;

    //public List<EnnemySO> ennemies;
}
