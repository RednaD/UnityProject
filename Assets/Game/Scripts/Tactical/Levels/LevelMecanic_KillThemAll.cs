using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMecanic_KillThemAll : MonoBehaviour, ILevelMecanic
{
    public EventSO          onVictoryEvent;
    public GroupeSO_TNPC    enemiesToKill;


    public void CheckVictoryConditions()
    {
        Debug.Log("Checking victory conditions...");
        Debug.Log("enemiesToKill.v.Count = " + enemiesToKill.v.Count);
        if (enemiesToKill.v.Count == 0)
        {
            Debug.Log("You won! Congratulation!");
            onVictoryEvent.Raise();
        }
    }
}
