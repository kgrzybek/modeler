using Modeler.EventsFlowModel;

namespace Modeler.Full.Sample.EventsFlow.Events;

public class EmailSentEvent : Event
{
    public static Event Create() => new EmailSentEvent()
        .WithName("Email Sent");
}