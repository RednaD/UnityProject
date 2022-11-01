using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEventSOListener<T>
{
    void OnEventRaised(T item);
}
