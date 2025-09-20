using Modeler.Models.Components;

namespace Modeler.Views.Components.Diagram;

public class VisibleComponent
{
    public VisibleComponent(IComponent component, int nestedComponentsLevel = 0)
    {
        Component = component;
        NestedComponentsLevel = nestedComponentsLevel;
    }

    public IComponent Component { get; }
    
    public int NestedComponentsLevel { get; }
}