using Modeler.Models.Common;
using Modeler.Views.Common;

namespace Modeler.Views.Data.DataModelDiagrams.Mermaid;

public abstract class MermaidDataModelView : IView
{
    public List<VisibleStructureElement> VisibleStructureElements { get; protected init; } = [];
}
