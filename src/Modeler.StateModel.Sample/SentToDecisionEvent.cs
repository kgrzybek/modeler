namespace Modeler.StateModel.Sample;

public class SentToDecisionEvent : TransitionEvent
{
    public static SentToDecisionEvent Create() => new SentToDecisionEvent();

    private SentToDecisionEvent() : base("Sent To Decision")
    {
    }
}