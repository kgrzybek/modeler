namespace Modeler.StateModel.Sample.Models.Events;

public class AcceptedEvent : TransitionEvent
{
    public static AcceptedEvent Create() => new AcceptedEvent();
    
    private AcceptedEvent() : base("Accepted")
    {
    }
}