namespace Modeler.ConceptualModel.Views.Shared;

public class RelationshipNote
{
    public RelationshipNote(
        string relationshipCode,
        string content,
        RelationshipNoteLocation location = RelationshipNoteLocation.NotSpecified)
    {
        Content = content;
        RelationshipCode = relationshipCode;
        Location = location;
    }

    public string Content { get; }
    
    public string RelationshipCode { get; }
    
    public RelationshipNoteLocation Location { get; }
}