using Models.Elements;

namespace Modeler.ConceptualModel.Views.Shared;

public abstract class ConceptsClassDiagramView : IView
{
    public List<VisibleEntity> VisibleEntities { get; protected init; } = [];
    
    public List<RelationshipNote> RelationshipNotes { get; protected init; } = [];
}