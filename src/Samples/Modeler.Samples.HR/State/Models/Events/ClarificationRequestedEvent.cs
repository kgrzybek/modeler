using Modeler.Models.StateMachine;

namespace Modeler.Samples.HR.State.Models.Events;

public class ClarificationRequestedEvent : TransitionEvent
{
    public static ClarificationRequestedEvent Create() => new ClarificationRequestedEvent();

    private ClarificationRequestedEvent() : base("Clarification Requested")
    {
    }
}