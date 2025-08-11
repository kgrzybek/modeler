using Modeler.StateModel;

namespace Modeler.Full.Sample.State.Models.Events;

public class RejectedEvent : TransitionEvent
{
    public static RejectedEvent Create() => new RejectedEvent();

    private RejectedEvent() : base("Rejected")
    {
    }
}