using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBehaviour : MonoBehaviour
{
    public IMovementBehaviour   move;
    //public ISelectable          selection;

    public int                  life;
    public int                  lifeMax;
    public WeaponSO             weapon;

    // ODO REMOVE
    public StateMachine         stateMachine;
    public StateSO              moveState;

    //  CHARACTER BASE
    void Awake()
    {
        move = GetComponent<IMovementBehaviour>();
        //selection = GetComponent<ISelectable>();
    }

    public void Reset()
    {
        move.Reset();
        //selection.Reset();
    }
}
