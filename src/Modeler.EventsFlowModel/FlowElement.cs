namespace Modeler.EventsFlowModel;

public abstract class FlowElement
{
    public string Name { get; protected set; } = "Undefined";
    
    public string Id { get; protected set; } = Guid.NewGuid().ToString();
}