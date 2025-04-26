namespace Modeler.StateModel.Sample.Models.Events;

public class ClarificationRequestedEvent : TransitionEvent
{
    public static ClarificationRequestedEvent Create() => new ClarificationRequestedEvent();

    public ClarificationRequestedEvent() : base("Clarification Requested")
    {
    }
}