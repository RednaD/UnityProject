using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class GameController : MonoBehaviour
{
    public IController          controller;

    public void Awake()
    {
        controller = GetComponent<IController>();
    }

    public void Update()
    {
        controller.HandleInput();
    }
}

public interface IController
{
    public void HandleInput();
}
