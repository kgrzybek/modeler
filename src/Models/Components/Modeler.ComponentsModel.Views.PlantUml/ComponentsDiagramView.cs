using Models.Elements;

namespace Modeler.ComponentsModel.Views.PlantUml;

public class ComponentsDiagramView : IView
{
    public ComponentsDiagramView(
        string id,
        List<IComponent> components)
    {
        Components = components;
        Id = id;
    }
    
    public string Id { get; }

    public List<IComponent> Components { get; }
}