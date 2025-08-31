namespace Modeler.Models.StateMachine;

public class Description : TransitionEvent
{
    public Description(string? name) : base(name ?? string.Empty)
    {
    }
}