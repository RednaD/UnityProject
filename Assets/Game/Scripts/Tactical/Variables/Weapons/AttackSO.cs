using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSO : ScriptableObject
{
    public WeaponTypeSO     type;

    public void ComputeDamages()
    {
        Debug.Log("Attack!!");
    }
}
