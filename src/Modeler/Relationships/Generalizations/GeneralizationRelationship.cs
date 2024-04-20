namespace Modeler.Relationships.Generalizations;

public class GeneralizationRelationship : Relationship
{
    internal GeneralizationRelationship(Entity general, Entity specific)
    {
        General = general;
        Specific = specific;
    }

    public Entity General { get; }
    
    public Entity Specific { get; }
}