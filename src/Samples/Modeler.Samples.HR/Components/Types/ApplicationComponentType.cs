using Modeler.Models.Components;

namespace Modeler.Samples.HR.Components.Types;

public record ApplicationComponentType : ComponentType
{
    public ApplicationComponentType() : base("Application")
    {
    }
}