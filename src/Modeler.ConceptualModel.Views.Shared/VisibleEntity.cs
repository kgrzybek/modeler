namespace Modeler.ConceptualModel.Views.Shared;

public class VisibleEntity
{
    public VisibleEntity(Entity entity, bool showAttributes = true)
    {
        Entity = entity;
        ShowAttributes = showAttributes;
    }

    public Entity Entity { get; } 
    
    public bool ShowAttributes { get; }
}