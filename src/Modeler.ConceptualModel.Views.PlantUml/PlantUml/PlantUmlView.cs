using Modeler.Relationships.Associations.Multiplicity;

namespace Modeler.ConceptualModel.Views.PlantUml.PlantUml;

public class PlantUmlView
{
    public PlantUmlView(
        List<VisibleEntity> entities,
        string path, 
        List<RelationshipNote>? relationshipNotes = null)
    {
        Entities = entities;
        Path = path;
        RelationshipNotes = relationshipNotes ?? new List<RelationshipNote>();
    }

    public List<VisibleEntity> Entities { get; }
    
    public List<RelationshipNote> RelationshipNotes { get; }

    public string Path { get; }
}