# Event System for Unity
This is a generic and general purpose system for dispatching and receiving game wide events in Unity.
It can be used for anything from notifying relevant components of game start, end, score changes, audio triggers, to light interaction between components.

### Example:

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
