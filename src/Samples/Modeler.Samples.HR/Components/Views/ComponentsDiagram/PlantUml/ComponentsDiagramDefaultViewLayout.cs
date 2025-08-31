using Modeler.Models.Components;
using Modeler.Samples.HR.Components.Types;
using Modeler.Views.Components.ComponentsDiagram;

namespace Modeler.Samples.HR.Components.Views.ComponentsDiagram.PlantUml;

public class ComponentsDiagramDefaultViewLayout : IComponentsDiagramViewLayout
{
    public string GetComponentTypeColor(ComponentType componentType)
    {
        return componentType switch
        {
            ExternalSystemComponentType => "#FFD2BE",
            _ => string.Empty
        };
    }

    public int IndentSize => 4;
}