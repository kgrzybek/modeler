namespace Modeler.EventsFlowModel.Sample.Events;

public class SmsSentEvent : Event
{
    public static Event Create() => new SmsSentEvent()
        .WithName("SMS Sent");
}