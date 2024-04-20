namespace Modeler.Relationships.Associations;

public class AssociationRelationship : Relationship
{
    private readonly List<Entity> _entities;
    
    public AssociationRelationship(AssociationDirectedRelationship sourceToTarget, AssociationDirectedRelationship targetToSource)
    {
        SourceToTarget = sourceToTarget;
        TargetToSource = targetToSource;
        
        _entities = new List<Entity>
        {
            SourceToTarget.From, 
            SourceToTarget.To
        };
    }

    public AssociationDirectedRelationship SourceToTarget { get; }
    
    public AssociationDirectedRelationship TargetToSource { get; }

    protected override List<Entity> BetweenEntities()
    {
        return _entities;
    }
}