namespace Modeler.EventsFlowModel;

public abstract class Event : FlowElement
{
    public List<CommandTrigger> CommandTriggers { get; } = new List<CommandTrigger>();
    
    protected Event WithName(
        string name)
    {
        this.Name = name;
        
        this.Id = Name.Replace(" ", "_").ToLower();

        return this;
    }

    public void Triggers(Command command)
    {
        CommandTriggers.Add(new CommandTrigger(command));
    }
}