namespace Modeler.EventsFlowModel.Sample.Events;

public class EmailSentEvent : Event
{
    public static Event Create() => new EmailSentEvent()
        .WithName("Email Sent");
}