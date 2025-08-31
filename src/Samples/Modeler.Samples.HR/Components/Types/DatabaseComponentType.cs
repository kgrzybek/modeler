using Modeler.Models.Components;

namespace Modeler.Samples.HR.Components.Types;

public record DatabaseComponentType : ComponentType
{
    public DatabaseComponentType() : base("Database")
    {
    }
}