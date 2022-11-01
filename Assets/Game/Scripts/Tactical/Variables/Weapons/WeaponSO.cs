using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "W_", menuName = "VariableSO/WeaponSO")]
public class WeaponSO : ScriptableObject
{
    public WeaponTypeSO     type;
    public int              range;
    public int              power;
    public WeaponEffectSO   effect;
    public int              effectProb;
    public int              effectPower;
    public AttackSO         attack1;
    public AttackSO         attack2;
}
