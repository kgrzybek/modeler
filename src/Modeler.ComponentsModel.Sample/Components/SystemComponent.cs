namespace Modeler.ComponentsModel.Sample.Components;

public class SystemComponent : Component
{
    private SystemComponent() : base("System")
    {
    }

    public static Component Create() => ComponentBuilder
        .Create(new SystemComponent())
        .AddChild(new BackendComponent(), backendComponent => backendComponent
            .AddChild(new ApiComponent())
            .AddChild(new DomainComponent())
            .AddChild(new InfrastructureComponent())
            .AddChild(new ApplicationComponent()))
        .AddChild(new FrontendComponent())
        .AddChild(new DatabaseComponent())
        .Build();
}