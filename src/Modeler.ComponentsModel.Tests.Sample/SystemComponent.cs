namespace Modeler.ComponentsModel.Tests.Sample;

public class SystemComponent : Component
{
    private SystemComponent(string name) : base(name)
    {
    }

    public static Component Create() => ComponentBuilder
        .Create(new SystemComponent("System"))
        .AddChild(new BackendComponent("Backend"), backendComponent => backendComponent
            .AddChild(new ApiComponent("Api"), apiComponent => apiComponent
                .AddChild(new ModuleComponent("Module"))))
        .AddChild(new FrontendComponent("Frontend"))
        .Build();
}

public class ApiComponent : Component
{
    public ApiComponent(string name) : base(name)
    {
    }
}

public class ModuleComponent : Component
{
    public ModuleComponent(string name) : base(name)
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
