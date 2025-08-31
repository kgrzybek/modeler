using Modeler.Models.Common;
using Modeler.Views.Common;

namespace Modeler.Views.Data.DataModelDiagrams.PlantUml;

public abstract class PlantUmlDataModelView : IView
{
    public List<VisibleStructureElement> VisibleStructureElements { get; protected init; } = [];
}