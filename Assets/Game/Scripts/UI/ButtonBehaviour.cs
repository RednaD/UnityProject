using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehaviour : MonoBehaviour
{
    public BoolVariable isClickedOn;

    public void SetState()
    {
        isClickedOn.v = true;
    }
}
