namespace Modeler.StateModel.Tests.Sample;

public class ClarificationRequestedEvent : TransitionEvent
{
    public static ClarificationRequestedEvent Create() => new ClarificationRequestedEvent();

    public ClarificationRequestedEvent() : base("Clarification Requested")
    {
    }
}