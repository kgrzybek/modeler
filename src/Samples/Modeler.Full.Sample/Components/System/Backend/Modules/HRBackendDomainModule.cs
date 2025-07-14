using Modeler.ComponentsModel;
using Modeler.Full.Sample.Components.Types;
using Models.Elements;

namespace Modeler.Full.Sample.Components.System.Backend.Modules;

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