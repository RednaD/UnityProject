using UnityEngine;

[CreateAssetMenu(fileName = "E_", menuName = "EventSO/EventSO")]
public class EventSO : EventSOBase<Void>
{
    public void Raise() => Raise(new Void());
}
