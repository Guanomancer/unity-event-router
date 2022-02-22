using System;
using System.Collections.Generic;
using UnityEngine;

namespace Guanomancer.EventRouting
{
    public static class EventRouter<T>
        where T : IEventData
    {
        private static Dictionary<string, Type> _typeCache = new Dictionary<string, Type>();

        private static List<IEventSubscriber> _subscribers;

        public static void Subscribe<ET>(IEventSubscriber subscriber)
            where ET : IEventData
            => Subscribe(typeof(ET), subscriber);

        public static void Subscribe(string eventTypeName, string assemblyName, IEventSubscriber subscriber)
        {
            if (_typeCache.ContainsKey(eventTypeName))
            {
                Subscribe(_typeCache[eventTypeName], subscriber);
                return;
            }

            if(!AppDomain.CurrentDomain.GetTypeByName(eventTypeName, assemblyName, out Type type))
                throw new UnityException($"Unable to subscribe to event type {eventTypeName} in assembly {assemblyName}.");
            
            Subscribe(type, subscriber);
        }

        public static void Subscribe(Type eventType, IEventSubscriber subscriber)
        {

        }

        public static void Unsubscribe<ET>(IEventSubscriber subscriber)
            where ET : IEventData
            => Unsubscribe(typeof(ET), subscriber);

        public static void Unsubscribe(string eventTypeName, string assemblyName, IEventSubscriber subscriber)
        {
            if (!AppDomain.CurrentDomain.GetTypeByName(eventTypeName, assemblyName, out Type type))
                throw new UnityException($"Unable to subscribe to event type {eventTypeName} in assembly {assemblyName}.");
            Subscribe(type, subscriber);
        }

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
