using Modeler.ComponentsModel;

namespace Modeler.Full.Sample.Components.Types;

public record ModuleComponentType : ComponentType
{
    public ModuleComponentType() : base("Module")
    {
    }
}