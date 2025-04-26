namespace Modeler.DataModel.PostgreSQL.Views.PlantUml;

public class PlantUmlDataModelView
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