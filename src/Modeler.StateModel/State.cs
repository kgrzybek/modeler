namespace Modeler.StateModel;

public abstract class State
{
    protected State(string name)
    {
        Name = name;
        Id = Name.ToLower().Replace(" ", "_");
    }

    public string Name { get; }
    
    public string Id { get; }
}

public class InitialState : State
{
    public InitialState() : base("Initial")
    {
    }
}

public class EndState : State
{
    public EndState() : base("End")
    {
    }
}