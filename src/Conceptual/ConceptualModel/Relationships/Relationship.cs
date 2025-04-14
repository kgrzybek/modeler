namespace Modeler.ConceptualModel.Relationships;

public abstract class Relationship
{
    public abstract List<Entity> BetweenEntities();
    
    public bool ForEntity(Entity entity)
    {
        return BetweenEntities().Contains(entity);
    }
}