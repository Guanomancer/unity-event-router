using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Guanomancer.EventRouting
{
    public class RoutingTest : MonoBehaviour, IEventData
    {
        private void Awake()
        {
            ER<IEventData>.Event += (e) => { Debug.Log(e); };
            ER<RoutingTest>.Event += (e) => { Debug.Log(e); };
            ER<IEventData>.Dispatch(new MyStartEvent { });
            ER<IEventData>.Dispatch(new MyStopEvent { });
            ER<RoutingTest>.Dispatch(this);
        }
    }
}
