using Modeler.ComponentsModel.Sample.Components.Types;

namespace Modeler.ComponentsModel.Sample.Components.HRSystem.Frontend;

public class HRFrontendApplication : Component
{
    public const string ComponentName = "HR Frontend";
    
    public HRFrontendApplication() : base(ComponentName, new ApplicationComponentType())
    {
    }
}