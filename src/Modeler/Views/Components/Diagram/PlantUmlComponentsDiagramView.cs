using Modeler.Models.Components;
using Modeler.Views.Common;

namespace Modeler.Views.Components.Diagram;

public abstract class PlantUmlComponentsDiagramView : IView
{
    public List<VisibleComponent> VisibleComponents { get; protected init; } = [];
}

public class VisibleComponent
{
    public VisibleComponent(IComponent component, int nestedComponentsLevel = 0)
    {
        Component = component;
        NestedComponentsLevel = nestedComponentsLevel;
    }

    public IComponent Component { get; set; }
    
    public int NestedComponentsLevel { get; set; }
}