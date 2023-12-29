using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public ILevelMecanic    levelMecanic;
    public LevelSO          level;
    public GridManager      Grid;

    public void Awake()
    {
        levelMecanic = GetComponent<ILevelMecanic>();
    }

    public void Init()
    {
        Grid.Init();

    }
}
