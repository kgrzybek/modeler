using Modeler.EventsFlowModel;

namespace Modeler.Full.Sample.EventsFlow.Events;

public class SmsSentEvent : Event
{
    public static Event Create() => new SmsSentEvent()
        .WithName("SMS Sent");
}