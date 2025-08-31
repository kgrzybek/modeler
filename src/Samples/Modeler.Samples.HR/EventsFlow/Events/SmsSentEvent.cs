using Modeler.Models.EventsFlow;

namespace Modeler.Samples.HR.EventsFlow.Events;

public class SmsSentEvent : Event
{
    public static Event Create() => new SmsSentEvent()
        .WithName("SMS Sent");
}