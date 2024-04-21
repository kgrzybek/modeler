namespace Modeler.ConceptualModel.Views.Shared;

public class ClassDiagramView
{
    public ClassDiagramView(
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