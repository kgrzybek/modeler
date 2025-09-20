using Modeler.Models.Components;

namespace Modeler.Views.Components.Diagram;

public class HiddenRelationship
{
    public HiddenRelationship(IComponent source, IComponent target)
    {
        Source = source;
        Target = target;
    }

    public IComponent Source { get; }
    
    public IComponent Target { get; }
}