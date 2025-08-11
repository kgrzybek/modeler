using Modeler.StateModel;

namespace Modeler.Full.Sample.State.Models.Events;

public class SentToDecisionEvent : TransitionEvent
{
    public static SentToDecisionEvent Create() => new SentToDecisionEvent();

    private SentToDecisionEvent() : base("Sent To Decision")
    {
    }
}