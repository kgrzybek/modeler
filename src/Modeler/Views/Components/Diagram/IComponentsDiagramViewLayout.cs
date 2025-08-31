using Modeler.ComponentsModel;

namespace Modeler.Views.Components.ComponentsDiagram;

public interface IComponentsDiagramViewLayout
{
    public string GetComponentTypeColor(ComponentType componentType);
    
    public int IndentSize { get; }
}