namespace Modeler.Models.Components;

public class ContainsComponentRelationship : ComponentRelationship
{
    public ContainsComponentRelationship(IComponent source, IComponent target) : base(source, target)
    {
    }
}