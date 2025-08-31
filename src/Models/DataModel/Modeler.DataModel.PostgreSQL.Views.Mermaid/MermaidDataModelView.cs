using Models.Elements;

namespace Modeler.DataModel.PostgreSQL.Views.Mermaid;

public abstract class MermaidDataModelView : IView
{
    public List<VisibleStructureElement> VisibleStructureElements { get; protected init; } = [];
}
