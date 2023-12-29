using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level_", menuName = "Tactical/LevelSO")]
public class LevelSO : ScriptableObject
{
    public ConditionsVictoireSO ConditionVictoire;

    public PartySO_GO           enemiesPool;

}
