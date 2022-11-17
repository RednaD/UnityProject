using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Zone
{
    public void OnTriggerEnter(Collider body);
    public void OnTriggerExit(Collider body);
}
