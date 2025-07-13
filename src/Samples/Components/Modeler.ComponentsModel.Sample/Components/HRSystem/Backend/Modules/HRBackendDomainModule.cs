using Modeler.ComponentsModel.Sample.Components.Types;
using Models.Elements;

namespace Modeler.ComponentsModel.Sample.Components.HRSystem.Backend.Modules;

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