namespace Modeler.Relationships.Associations;

public class AssociationRelationship : Relationship
{
    public AssociationRelationship(AssociationDirectedRelationship sourceToTarget, AssociationDirectedRelationship targetToSource)
    {
        SourceToTarget = sourceToTarget;
        TargetToSource = targetToSource;
    }

    public AssociationDirectedRelationship SourceToTarget { get; }
    
    public AssociationDirectedRelationship TargetToSource { get; }
}