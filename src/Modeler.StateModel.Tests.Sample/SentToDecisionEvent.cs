namespace Modeler.StateModel.Tests.Sample;

public class SentToDecisionEvent : TransitionEvent
{
    public static SentToDecisionEvent Create() => new SentToDecisionEvent();

    private SentToDecisionEvent() : base("SentToDecision")
    {
    }
}