namespace Modeler.ComponentsModel;

public abstract class ComponentRelationship
{
    protected ComponentRelationship(Component source, Component target, string? name = null)
    {
        Source = source;
        Target = target;
        Name = name;
    }

    public Component Source { get; }
    
    public Component Target { get; }
    
    public string? Name { get; }
}