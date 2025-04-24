namespace Modeler.ComponentsModel.Tests.Sample;

public class SystemComponent : Component
{
    private SystemComponent(string name) : base(name)
    {
    }

    public static Component Create() => ComponentBuilder
        .Create(new SystemComponent("System"))
        .AddChild(new BackendComponent("Backend"), backendComponent => backendComponent
            .AddChild(new ApiComponent("Api"))
            .AddChild(new DomainComponent("Domain"))
            .AddChild(new InfrastructureComponent("Infrastructure"))
            .AddChild(new ApplicationComponent("Application")))
        .AddChild(new FrontendComponent("Frontend"))
        .AddChild(new DatabaseComponent("Database"))
        .Build();
}

public class ApiComponent : Component
{
    public ApiComponent(string name) : base(name)
    {
    }
}

public class DomainComponent : Component
{
    public DomainComponent(string name) : base(name)
    {
    }
}

public class ApplicationComponent : Component
{
    public ApplicationComponent(string name) : base(name)
    {
    }
}

public class InfrastructureComponent : Component
{
    public InfrastructureComponent(string name) : base(name)
    {
    }
}

public class BackendComponent : Component
{
    public BackendComponent(string name) : base(name)
    {
    }
}

public class FrontendComponent : Component
{
    public FrontendComponent(string name) : base(name)
    {
    }
}

public class DatabaseComponent : Component
{
    public DatabaseComponent(string name) : base(name)
    {
    }
}