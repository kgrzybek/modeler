namespace Modeler.ConceptualModel.Relationships.Generalizations;

public class GeneralizationRelationship : Relationship
{
    private readonly List<Entity> _entities;
    
    internal GeneralizationRelationship(Entity general, Entity specific)
    {
        General = general;
        Specific = specific;
        
        _entities = new List<Entity>
        {
            General, 
            Specific
        };
    }

    public Entity General { get; }
    
    public Entity Specific { get; }

    protected override List<Entity> BetweenEntities()
    {
        return _entities;
    }
}