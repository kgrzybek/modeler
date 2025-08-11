using Modeler.StateModel;

namespace Modeler.Full.Sample.State.Models.Events;

public class ClarificationRequestedEvent : TransitionEvent
{
    public static ClarificationRequestedEvent Create() => new ClarificationRequestedEvent();

    private ClarificationRequestedEvent() : base("Clarification Requested")
    {
    }
}