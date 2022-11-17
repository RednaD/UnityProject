using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class GameController : MonoBehaviour
{
    public IController          controller;

    public bool                 isOccupied;

    public void Awake()
    {
        controller = GetComponent<IController>();
        isOccupied = false;
    }

    public void Update()
    {
        if (!isOccupied) controller.HandleInput();
    }


    public void SetOccupied(bool state)
    {
        isOccupied = state;
    }
}

public interface IController
{
    public void HandleInput();
}
