using Modeler.Models.Components;

namespace Modeler.Samples.HR.Components.Types;

public record ModuleComponentType : ComponentType
{
    public ModuleComponentType() : base("Module")
    {
    }
}