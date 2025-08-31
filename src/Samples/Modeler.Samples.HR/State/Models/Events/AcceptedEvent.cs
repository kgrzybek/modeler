using Modeler.Models.StateMachine;

namespace Modeler.Samples.HR.State.Models.Events;

public class AcceptedEvent : TransitionEvent
{
    public static AcceptedEvent Create() => new AcceptedEvent();
    
    private AcceptedEvent() : base("Accepted")
    {
    }
}