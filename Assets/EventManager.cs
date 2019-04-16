using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;
using static Helpers;

public class EventManager : MonoBehaviour
{

    private Dictionary<string, UnityEvent<DiceType, int>> eventDictionary;

    private static EventManager eventManager;
    public class GameEvent : UnityEvent<DiceType, int> { };

    public static EventManager instance
    {
        get
        {
            if (!eventManager)
            {
                eventManager = FindObjectOfType(typeof(EventManager)) as EventManager;

                if (!eventManager)
                {
                    Debug.LogError("There needs to be one active EventManger script on a GameObject in your scene.");
                }
                else
                {
                    eventManager.Init();
                }
            }

            return eventManager;
        }
    }

    void Init()
    {
        if (eventDictionary == null)
        {
            eventDictionary = new Dictionary<string, UnityEvent<DiceType, int>>();
        }
    }

    public static void StartListening(string eventName, UnityAction<DiceType, int> listener)
    {
        UnityEvent<DiceType, int> thisEvent = null;
        if (instance.eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.AddListener(listener);
        }
        else
        {
            thisEvent = new GameEvent();
            thisEvent.AddListener(listener);
            instance.eventDictionary.Add(eventName, thisEvent);
        }
    }

    public static void StopListening(string eventName, UnityAction<DiceType, int> listener)
    {
        if (eventManager == null) return;
        UnityEvent<DiceType, int> thisEvent = null;
        if (instance.eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.RemoveListener(listener);
        }
    }

    public static void TriggerEvent(string eventName, DiceType dice, int value)
    {
        UnityEvent<DiceType, int> thisEvent = null;
        if (instance.eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.Invoke(dice, value);
        }
    }
}