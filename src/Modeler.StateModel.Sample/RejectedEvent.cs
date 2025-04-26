namespace Modeler.StateModel.Sample;

public class RejectedEvent : TransitionEvent
{
    public static RejectedEvent Create() => new RejectedEvent();

    private RejectedEvent() : base("Rejected")
    {
    }
}