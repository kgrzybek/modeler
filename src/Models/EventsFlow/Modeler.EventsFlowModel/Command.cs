namespace Modeler.EventsFlowModel;

public abstract class Command : FlowElement
{
    protected Command WithName(
        string name)
    {
        this.Name = name;
        
        this.Id = Name.Replace(" ", "_").ToLower();

        return this;
    }
    
    public List<EventTrigger> EventTriggers { get; } = new List<EventTrigger>();

    public void Triggers(Event employeeAddedEvent)
    {
        EventTriggers.Add(new EventTrigger(employeeAddedEvent));
    }
}