using Modeler.Models.StateMachine;

namespace Modeler.Samples.HR.State.Models.Events;

public class RejectedEvent : TransitionEvent
{
    public static RejectedEvent Create() => new RejectedEvent();

    private RejectedEvent() : base("Rejected")
    {
    }
}