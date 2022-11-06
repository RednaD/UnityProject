using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TacticalEnum", menuName = "TacticalEnum")]
public class TacticalEnum : ScriptableObject
{
    public StateSO  moving;
    public StateSO  attacking;
    public StateSO  usingSpecial;
}
