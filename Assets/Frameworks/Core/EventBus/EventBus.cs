using System;
using System.Collections.Generic;

public static class EventBus
{
    private static Dictionary<Type, Delegate> eventTable = new();

    public static void Subscribe<T>(Action<T> callback)
    {
        if (eventTable.TryGetValue(typeof(T), out var del))
            eventTable[typeof(T)] = Delegate.Combine(del, callback);
        else
            eventTable[typeof(T)] = callback;
    }

    public static void Publish<T>(T eventData)
    {
        if (eventTable.TryGetValue(typeof(T), out var del))
        {
            var callback = del as Action<T>;
            callback?.Invoke(eventData);
        }
    }
}