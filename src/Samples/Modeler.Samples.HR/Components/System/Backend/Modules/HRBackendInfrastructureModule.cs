using Modeler.Models.Common;
using Modeler.Models.Common.Elements;
using Modeler.Models.Components;
using Modeler.Samples.HR.Components.Types;

namespace Modeler.Samples.HR.Components.System.Backend.Modules;

public class HRBackendInfrastructureModule : Component
{
    public static IElement Create()
    {
        return new HRBackendInfrastructureModule();
    }
    public HRBackendInfrastructureModule() : base("HR Backend Infrastructure", new ModuleComponentType())
    {
    }
}