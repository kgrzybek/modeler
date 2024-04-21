namespace Modeler.ConceptualModel.Views.PlantUml.PlantUml;

public class PlantUmlView
{
    public PlantUmlView(
        string id,
        List<VisibleEntity> entities,
        List<RelationshipNote>? relationshipNotes = null)
    {
        Entities = entities;
        RelationshipNotes = relationshipNotes ?? new List<RelationshipNote>();
        Id = id;
    }
    
    public string Id { get; }

    public List<VisibleEntity> Entities { get; }
    
    public List<RelationshipNote> RelationshipNotes { get; }
}