namespace Modeler.DataModel.PostgreSQL.Views.Mermaid;

public class MermaidDataModelView
{
    public MermaidDataModelView(
        List<VisibleStructureElement> visibleTables,
        string path)
    {
        VisibleStructureElements = visibleTables;
        Path = path;
    }

    public List<VisibleStructureElement> VisibleStructureElements { get; }

    public string Path { get; }
}
