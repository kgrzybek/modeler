using Modeler.Relationships.Associations.Multiplicity;

namespace Modeler.Relationships.Associations.Builder;

public class FromTargetToSource
{
    private AssociationDirectedRelationship SourceToTarget { get; }
    
    internal FromTargetToSource(AssociationDirectedRelationship sourceToTarget)
    {
        SourceToTarget = sourceToTarget;
    }
    
    public AssociationRelationship AndInOpposite(string name, RelationshipMultiplicity multiplicity)
    {
        var targetToSource = new AssociationDirectedRelationship(name, SourceToTarget.To, multiplicity, SourceToTarget.From);

        return new AssociationRelationship(SourceToTarget, targetToSource);
    }
}