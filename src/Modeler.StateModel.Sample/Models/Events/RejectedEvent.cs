namespace Modeler.StateModel.Sample.Models.Events;

public class RejectedEvent : TransitionEvent
{
    public static RejectedEvent Create() => new RejectedEvent();

    private RejectedEvent() : base("Rejected")
    {
    }
}