using System;
using System.Collections.Generic;
using UnityEngine;

namespace Guanomancer.EventRouting
{
    public static class EventRouter<T>
        where T : IEventData
    {
        public static void Subscribe<ET>(IEventSubscriber subscriber)
            where ET : IEventData
            => Subscribe(typeof(ET), subscriber);

        public static void Subscribe(string assemblyName, string eventTypeName, IEventSubscriber subscriber)
        {

            Subscribe(typeof(EventRouter<IEventData>), subscriber);
        }

        public static void Subscribe(Type eventType, IEventSubscriber subscriber)
        {

        }

        public static void Unsubscribe<ET>(IEventSubscriber subscriber)
            where ET : IEventData
            => Unsubscribe(typeof(ET), subscriber);

        public static void Unsubscribe(Type eventType, IEventSubscriber subscriber)
        {

        }

        public static void Dispatch(T eventData)
        {

        }
    }

    public interface IEventSubscriber { }

    public interface IEventData { }

    public struct MyStartEvent : IEventData { }
    public struct MyStopEvent : IEventData { }
}
