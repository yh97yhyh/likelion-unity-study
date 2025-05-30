using System.Collections.Generic;
using System;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    private static EventManager _instance;
    public static EventManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindFirstObjectByType<EventManager>();

                if (_instance == null)
                {
                    GameObject gameObject = new GameObject("EventManager");
                    _instance = gameObject.AddComponent<EventManager>();
                }
            }

            return _instance;
        }
    }

    private Dictionary<string, Action<object>> _eventDictionary = new Dictionary<string, Action<object>>();

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }
        _instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void AddListsner(string eventName, Action<object> listener)
    {
        if (_eventDictionary.TryGetValue(eventName, out Action<object> thisEvent))
        {
            thisEvent += listener;
            _eventDictionary[eventName] = thisEvent;
        }
        else
        {
            _eventDictionary.Add(eventName, listener);
        }
    }

    public void RemoveListener(string eventName, Action<object> listener)
    {
        if (_eventDictionary.TryGetValue(eventName, out Action<object> thisEvent))
        {
            thisEvent -= listener;
            _eventDictionary[eventName] = thisEvent;
        }
    }

    public void TriggerEvent(string eventName, object data = null)
    {
        if (_eventDictionary.TryGetValue(eventName, out Action<object> thisEvent))
        {
            thisEvent?.Invoke(data);
        }
    }
}
