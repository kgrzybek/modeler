using Modeler.ComponentsModel.Sample.Components.HRSystem.Backend;
using Modeler.ComponentsModel.Sample.Components.HRSystem.Backend.Modules;
using Modeler.ComponentsModel.Sample.Components.HRSystem.Database;
using Modeler.ComponentsModel.Sample.Components.HRSystem.Frontend;
using Modeler.ComponentsModel.Sample.Components.Types;

namespace Modeler.ComponentsModel.Sample.Components.HRSystem;

public class HRSystemBoundary : Component
{
    private HRSystemBoundary() : base("HR System", new BoundaryComponentType())
    {
    }

    public static Component Create() => ComponentBuilder
        .Create(new HRSystemBoundary())
        .AddChild(new HRBackendApplication(), backendComponent => backendComponent
            .AddChild(new HRBackendApiModule())
            .AddChild(new HRBackendDomainModule())
            .AddChild(new HRBackendInfrastructureModule())
            .AddChild(new HRBackendApplicationModule()))
        .AddChild(new HRFrontendApplication())
        .AddChild(new HRDatabase())
        .Build();
}