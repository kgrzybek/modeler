using Modeler.Models.Conceptual.Relationships.Associations.Multiplicity;

namespace Modeler.Models.Conceptual.Relationships.Associations.Builder;

public static class AssociationBuilder
{
    public static FromTargetToSource Where(Entity entity, string name, RelationshipMultiplicity multiplicity, Entity to)
    {
        var sourceToTarget = new AssociationDirectedRelationship(name, entity, multiplicity, to);

        return new FromTargetToSource(sourceToTarget);
    }
}