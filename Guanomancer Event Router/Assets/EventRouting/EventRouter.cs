using System;
using System.Collections.Generic;
using UnityEngine;

namespace Guanomancer.EventRouting
{
    public delegate void RoutedEvent<T>(T eventData) where T : IEventData;

    public static class ER<T> where T : IEventData
    {
        public static event RoutedEvent<T> Event;
        public static void Dispatch(T eventData)
            => Event.Invoke(eventData);
    }

    public interface IEventData { }

    public struct MyStartEvent : IEventData { }
    public struct MyStopEvent : IEventData { }
}
