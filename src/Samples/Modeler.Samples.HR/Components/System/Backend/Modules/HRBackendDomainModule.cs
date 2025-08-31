using Modeler.Models.Common;
using Modeler.Models.Common.Elements;
using Modeler.Models.Components;
using Modeler.Samples.HR.Components.Types;

namespace Modeler.Samples.HR.Components.System.Backend.Modules;

public class HRBackendDomainModule : Component
{
    public static IElement Create()
    {
        return new HRBackendDomainModule();
    }
    public HRBackendDomainModule() : base("HR Backend Domain", new ModuleComponentType())
    {
    }
}