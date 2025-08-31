using Modeler.Models.Components;

namespace Modeler.Samples.HR.Components.Types;

public record ExternalSystemComponentType : ComponentType
{
    public ExternalSystemComponentType() : base("External System")
    {
    }
}