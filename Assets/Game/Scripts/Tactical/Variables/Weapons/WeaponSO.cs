using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "W_", menuName = "VariableSO/WeaponSO")]
public class WeaponSO : CollectableSO
{
    public WeaponTypeSO     type;
    public int              range;
    public int              Power;
    public WeaponEffectSO   effect;
    public int              effectProb; // No proba here, what is prob?
    public int              effectPower;
    public AttackSO         attack1;
    public AttackSO         attack2;
}
