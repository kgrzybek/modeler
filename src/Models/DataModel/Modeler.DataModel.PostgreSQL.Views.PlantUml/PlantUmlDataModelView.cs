using Models.Elements;

namespace Modeler.DataModel.PostgreSQL.Views.PlantUml;

public class PlantUmlDataModelView : IView
{
    public PlantUmlDataModelView(
        List<VisibleStructureElement> visibleTables,
        string path)
    {
        VisibleStructureElements = visibleTables;
        Path = path;
    }

    public List<VisibleStructureElement> VisibleStructureElements { get; }

    public string Path { get; }
}