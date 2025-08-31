using Modeler.Models.EventsFlow;

namespace Modeler.Samples.HR.EventsFlow.Events;

public class EmailSentEvent : Event
{
    public static Event Create() => new EmailSentEvent()
        .WithName("Email Sent");
}