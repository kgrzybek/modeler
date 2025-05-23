namespace Modeler.ConceptualModel.Relationships.Associations;

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

    public override List<Entity> BetweenEntities()
    {
        return _entities;
    }
}