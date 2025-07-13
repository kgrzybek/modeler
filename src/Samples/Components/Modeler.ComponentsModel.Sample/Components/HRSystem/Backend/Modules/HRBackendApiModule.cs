using Modeler.ComponentsModel.Sample.Components.Types;
using Models.Elements;

namespace Modeler.ComponentsModel.Sample.Components.HRSystem.Backend.Modules;

public class HRBackendApiModule : Component
{
    public static IElement Create()
    {
        return new HRBackendApiModule();
    }
    private HRBackendApiModule() : base("HR Backend Api", new ModuleComponentType())
    {
    }
}