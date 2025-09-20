namespace Modeler.Models.Components.Relationships;

public class DependencyComponentRelationship : ComponentRelationship
{
    public DependencyComponentRelationship(IComponent source, IComponent target) : base(source, target)
    {
    }
}