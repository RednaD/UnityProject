using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ConditionsVictoireEnum", menuName = "Tactical/ConditionsVictoireEnum")]
public class ConditionsVictoireEnum : ScriptableObject
{
    public ConditionsVictoireSO  killThemAll;
    public ConditionsVictoireSO  beatBoss;
    public ConditionsVictoireSO  reachZone;
    public ConditionsVictoireSO  survive;
}