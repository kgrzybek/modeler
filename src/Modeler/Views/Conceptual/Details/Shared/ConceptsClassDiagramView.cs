using Modeler.Models.Common;
using Modeler.Views.Common;

namespace Modeler.Views.Conceptual.ConceptDetails.Shared;

public abstract class ConceptsClassDiagramView : IView
{
    public List<VisibleEntity> VisibleEntities { get; protected init; } = [];
    
    public List<RelationshipNote> RelationshipNotes { get; protected init; } = [];
}