using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Event", menuName = "Game Event", order = 52)]
public class Event : ScriptableObject
{
    private List<EventListener> _eventListeners = new List<EventListener>();

    public void Register(EventListener eventListener)
    {
        _eventListeners.Add(eventListener);
    }

    public void Unregister(EventListener eventListener)
    {
        _eventListeners.Remove(eventListener);
    }

    public void Occured(GameObject gameObject)
    {
        foreach (EventListener eventListener in _eventListeners)
        {
            eventListener.OnEventOccurs(gameObject);
        }
    }
}
