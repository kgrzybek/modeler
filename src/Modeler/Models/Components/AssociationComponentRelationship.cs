namespace Modeler.Models.Components;

public class AssociationComponentRelationship : ComponentRelationship
{
    public AssociationComponentRelationship(Component source, Component target, string? name = null) : base(source, target, name)
    {
    }
}