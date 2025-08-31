using Modeler.Models.Common.Elements;

namespace Modeler.Models.EventsFlow;

public abstract class FlowElement : IElement
{
    public string Name { get; protected set; } = "Undefined";
    
    public string Id { get; protected set; } = Guid.NewGuid().ToString();
}