using Modeler.ComponentsModel;
using Modeler.Full.Sample.Components.Types;
using Models.Elements;

namespace Modeler.Full.Sample.Components.System.Backend.Modules;

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