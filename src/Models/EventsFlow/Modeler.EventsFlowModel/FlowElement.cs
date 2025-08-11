using Models.Elements;

namespace Modeler.EventsFlowModel;

public abstract class FlowElement : IElement
{
    public string Name { get; protected set; } = "Undefined";
    
    public string Id { get; protected set; } = Guid.NewGuid().ToString();
}