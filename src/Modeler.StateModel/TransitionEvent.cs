namespace Modeler.StateModel;

public abstract class TransitionEvent
{
    protected TransitionEvent(string name)
    {
        Name = name;
    }

    public string Name { get; }
}

public class Description : TransitionEvent
{
    public Description(string? name) : base(name ?? string.Empty)
    {
    }
}