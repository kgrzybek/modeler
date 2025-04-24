namespace Modeler.ComponentsModel.Views.PlantUml;

public class ComponentsDiagramView
{
    public ComponentsDiagramView(
        string id,
        List<Component> components)
    {
        Components = components;
        Id = id;
    }
    
    public string Id { get; }

    public List<Component> Components { get; }
}