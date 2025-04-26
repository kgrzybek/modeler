namespace Modeler.StateModel.Tests.Sample;

public class AcceptedEvent : TransitionEvent
{
    public static AcceptedEvent Create() => new AcceptedEvent();
    
    public AcceptedEvent() : base("Accepted")
    {
    }
}