using System;
using System.Collections.Generic;
using UnityEngine;

namespace Guanomancer.EventRouting
{
    public delegate void RoutedEvent<T>(T eventData) where T : IEventData;

    public static class EventRouter<T> where T : IEventData
    {
        public static event RoutedEvent<T> Event;

        private static string _debugColorString = "<color=#5555CC>";

        public static void SetDebugColor(Color color)
        {
            _debugColorString = string.Format("<color=#{0:X2}{1:X2}{2:X2}>",
                (byte)(color.r * 255f),
                (byte)(color.g * 255f),
                (byte)(color.b * 255f));
        }

        public static void Dispatch(T eventData)
        {
#if UNITY_EDITOR
            Debug.Log(string.Format("{0}{1}</color> event triggered.\n{2}", _debugColorString, eventData, JsonUtility.ToJson(eventData, true)));
#endif
            Event?.Invoke(eventData);
        }
    }

    public interface IEventData { }
}
