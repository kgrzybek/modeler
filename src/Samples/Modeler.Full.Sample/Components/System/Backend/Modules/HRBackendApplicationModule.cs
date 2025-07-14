using Modeler.ComponentsModel;
using Modeler.Full.Sample.Components.Types;
using Models.Elements;

namespace Modeler.Full.Sample.Components.System.Backend.Modules;

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