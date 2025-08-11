using Modeler.StateModel;

namespace Modeler.Full.Sample.State.Models.Events;

public class AcceptedEvent : TransitionEvent
{
    public static AcceptedEvent Create() => new AcceptedEvent();
    
    private AcceptedEvent() : base("Accepted")
    {
    }
}