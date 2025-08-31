using Models.Elements;

namespace Modeler.DataModel.PostgreSQL.Views.PlantUml;

public abstract class PlantUmlDataModelView : IView
{
    public List<VisibleStructureElement> VisibleStructureElements { get; protected init; } = [];
}