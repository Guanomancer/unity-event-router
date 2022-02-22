using Guanomancer.EventRouting;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Guanomancer
{
    public class RoutingTest : MonoBehaviour, IEventData
    {
        private void Awake()
        {
            EventRouter<MyEventCategory>.Event += (e) => { Debug.Log(e); };
        }

        private float _startTime;

        private void OnEnable()
        {
            _startTime = Time.time;
            EventRouter<MyEventCategory>.Dispatch(new MyStartEvent { });
        }

        private void OnDisable()
            => EventRouter<MyEventCategory>.Dispatch(new MyStopEvent { TotalSeconds = Time.time - _startTime });
    }

    public interface MyEventCategory : IEventData { }
    public struct MyStartEvent : MyEventCategory { }
    public struct MyStopEvent : MyEventCategory { public float TotalSeconds; }
}
