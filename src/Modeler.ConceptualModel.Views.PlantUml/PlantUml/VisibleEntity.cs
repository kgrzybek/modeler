namespace Modeler.ConceptualModel.Views.PlantUml.PlantUml;

public class VisibleEntity
{
    public VisibleEntity(Entity concept, bool showAttributes = true)
    {
        Concept = concept;
        ShowAttributes = showAttributes;
    }

    public Entity Concept { get; } 
    
    public bool ShowAttributes { get; }
}