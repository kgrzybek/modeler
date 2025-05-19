namespace Modeler.StateModel.Sample.Models.Events;

public class ClarificationRequestedEvent : TransitionEvent
{
    public static ClarificationRequestedEvent Create() => new ClarificationRequestedEvent();

    private ClarificationRequestedEvent() : base("Clarification Requested")
    {
    }
}