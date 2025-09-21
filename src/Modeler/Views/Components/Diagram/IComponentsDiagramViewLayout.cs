using Modeler.Models.Components;

namespace Modeler.Views.Components.Diagram;

public interface IComponentsDiagramViewLayout
{
    public string GetComponentTypeColor(ComponentType componentType);
    
    public int IndentSize { get; }
}