using Modeler.ComponentsModel.Sample.Components.Types;
using Modeler.ComponentsModel.Views.PlantUml;

namespace Modeler.ComponentsModel.Sample.Views;

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