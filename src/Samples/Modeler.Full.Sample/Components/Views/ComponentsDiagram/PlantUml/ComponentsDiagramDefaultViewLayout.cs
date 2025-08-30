using Modeler.ComponentsModel;
using Modeler.ComponentsModel.Views.PlantUml;
using Modeler.Full.Sample.Components.Types;

namespace Modeler.Full.Sample.Components.Views.ComponentsDiagram.PlantUml;

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