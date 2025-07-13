using Modeler.ComponentsModel.Sample.Components.Types;
using Models.Elements;

namespace Modeler.ComponentsModel.Sample.Components.HRSystem.Backend.Modules;

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