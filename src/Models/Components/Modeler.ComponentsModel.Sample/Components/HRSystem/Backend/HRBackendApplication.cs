using Modeler.ComponentsModel.Sample.Components.Types;

namespace Modeler.ComponentsModel.Sample.Components.HRSystem.Backend;

public class HRBackendApplication : Component
{
    public const string ComponentName = "HR Backend";
    
    public HRBackendApplication() : base(ComponentName, new ApplicationComponentType())
    {
    }
}