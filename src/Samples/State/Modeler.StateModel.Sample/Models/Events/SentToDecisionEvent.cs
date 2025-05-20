namespace Modeler.StateModel.Sample.Models.Events;

public class SentToDecisionEvent : TransitionEvent
{
    public static SentToDecisionEvent Create() => new SentToDecisionEvent();

    private SentToDecisionEvent() : base("Sent To Decision")
    {
    }
}