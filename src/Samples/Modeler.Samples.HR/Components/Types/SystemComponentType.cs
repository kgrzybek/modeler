using Modeler.Models.Components;

namespace Modeler.Samples.HR.Components.Types;

public record SystemComponentType : ComponentType
{
    public SystemComponentType() : base("System")
    {
    }
}