using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UiInteractionTypeEnum", menuName = "UI/InteractionTypes")]
public class InteractionTypeEnum : ScriptableObject
{
    public EnumSO  selection;
    public EnumSO  action;
}
