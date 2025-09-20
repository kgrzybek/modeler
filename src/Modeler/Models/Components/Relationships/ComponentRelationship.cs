namespace Modeler.Models.Components.Relationships;

public abstract class ComponentRelationship
{
    protected ComponentRelationship(IComponent source, IComponent target, string? name = null)
    {
        Source = source;
        Target = target;
        Name = name;
    }

    public IComponent Source { get; }
    
    public IComponent Target { get; }
    
    public string? Name { get; }
}