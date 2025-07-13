using Modeler.ComponentsModel.Sample.Components.Types;
using Models.Elements;

namespace Modeler.ComponentsModel.Sample.Components.HRSystem.Backend.Modules;

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