using Modeler.ComponentsModel.Sample.Components.HRSystem.Database;
using Modeler.ComponentsModel.Sample.Components.Types;
using Models.Elements;

namespace Modeler.ComponentsModel.Sample.Components.HRSystem.Frontend;

public class HRFrontendApplication : Component
{
    public static IElement Create()
    {
        return new HRFrontendApplication();
    }
    
    public const string ComponentName = "HR Frontend";
    
    public HRFrontendApplication() : base(ComponentName, new ApplicationComponentType())
    {
    }
}