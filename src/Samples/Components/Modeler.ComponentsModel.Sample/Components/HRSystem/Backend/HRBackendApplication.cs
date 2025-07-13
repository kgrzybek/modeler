using Modeler.ComponentsModel.Sample.Components.Types;
using Models.Elements;

namespace Modeler.ComponentsModel.Sample.Components.HRSystem.Backend;

public class HRBackendApplication : Component
{
    public static IElement Create()
    {
        return new HRBackendApplication();
    }
    
    public const string ComponentName = "HR Backend";
    
    public HRBackendApplication() : base(ComponentName, new ApplicationComponentType())
    {
    }
}