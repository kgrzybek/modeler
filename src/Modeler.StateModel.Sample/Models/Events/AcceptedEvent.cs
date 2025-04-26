namespace Modeler.StateModel.Sample.Models.Events;

public class AcceptedEvent : TransitionEvent
{
    public static AcceptedEvent Create() => new AcceptedEvent();
    
    public AcceptedEvent() : base("Accepted")
    {
    }
}