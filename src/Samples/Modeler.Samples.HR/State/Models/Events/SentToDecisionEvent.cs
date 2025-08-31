using Modeler.Models.StateMachine;

namespace Modeler.Samples.HR.State.Models.Events;

public class SentToDecisionEvent : TransitionEvent
{
    public static SentToDecisionEvent Create() => new SentToDecisionEvent();

    private SentToDecisionEvent() : base("Sent To Decision")
    {
    }
}