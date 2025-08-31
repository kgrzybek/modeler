namespace Modeler.Models.Components;

public class DependencyComponentRelationship : ComponentRelationship
{
    public DependencyComponentRelationship(IComponent source, IComponent target) : base(source, target)
    {
    }
}