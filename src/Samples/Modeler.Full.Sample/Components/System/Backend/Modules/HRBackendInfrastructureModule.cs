using Modeler.ComponentsModel;
using Modeler.Full.Sample.Components.Types;
using Models.Elements;

namespace Modeler.Full.Sample.Components.System.Backend.Modules;

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