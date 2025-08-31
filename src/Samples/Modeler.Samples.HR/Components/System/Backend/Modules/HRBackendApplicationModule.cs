using Modeler.Models.Common;
using Modeler.Models.Common.Elements;
using Modeler.Models.Components;
using Modeler.Samples.HR.Components.Types;

namespace Modeler.Samples.HR.Components.System.Backend.Modules;

public class HRBackendApplicationModule : Component
{
    public static IElement Create()
    {
        return new HRBackendApplicationModule();
    }
    public HRBackendApplicationModule() : base("HR Backend Application", new ModuleComponentType())
    {
    }
}