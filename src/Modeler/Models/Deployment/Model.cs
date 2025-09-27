using System;
using System.Collections.Generic;
using System.Linq;
using Modeler.Models.Common.Elements;
using Modeler.Models.Common.Models;
using Modeler.Models.Components;

namespace Modeler.Models.Deployment;

public abstract class Model : IModel
{
    private readonly List<DeploymentEnvironment> _environments;
    private readonly List<DeploymentServer> _servers;
    private readonly List<DeploymentRuntimeEnvironment> _runtimeEnvironments;
    private readonly List<IComponent> _components;
    private readonly List<EnvironmentServerAssignment> _environmentServers;
    private readonly List<ServerRuntimeEnvironmentAssignment> _serverRuntimeEnvironments;
    private readonly List<RuntimeComponentAssignment> _runtimeComponents;

    protected Model(ModelElementsRegistry elementsRegistry)
    {
        _environments = elementsRegistry.GetElements<DeploymentEnvironment>();
        _servers = elementsRegistry.GetElements<DeploymentServer>();
        _runtimeEnvironments = elementsRegistry.GetElements<DeploymentRuntimeEnvironment>();
        _components = elementsRegistry.GetElements<IComponent>();
        _environmentServers = new List<EnvironmentServerAssignment>();
        _serverRuntimeEnvironments = new List<ServerRuntimeEnvironmentAssignment>();
        _runtimeComponents = new List<RuntimeComponentAssignment>();
    }

    public DeploymentEnvironment GetEnvironment<T>() where T : DeploymentEnvironment
    {
        return GetElement(_environments, typeof(T));
    }

    public DeploymentServer GetServer<T>() where T : DeploymentServer
    {
        return GetElement(_servers, typeof(T));
    }

    public DeploymentRuntimeEnvironment GetRuntimeEnvironment<T>() where T : DeploymentRuntimeEnvironment
    {
        return GetElement(_runtimeEnvironments, typeof(T));
    }

    public T GetComponent<T>() where T : IComponent
    {
        var component = _components.OfType<T>().SingleOrDefault();

        if (component == null)
        {
            throw new Exception($"Component of type {typeof(T)} is not defined in the model");
        }

        return component;
    }

    public void AddServer(DeploymentEnvironment environment, DeploymentServer server)
    {
        ValidateEnvironment(environment);
        ValidateServer(server);

        if (_environmentServers.Any(x => x.Environment == environment && x.Server == server))
        {
            return;
        }

        _environmentServers.Add(new EnvironmentServerAssignment(environment, server));
    }

    public void AddRuntime(DeploymentServer server, DeploymentRuntimeEnvironment runtimeEnvironment)
    {
        ValidateServer(server);
        ValidateRuntimeEnvironment(runtimeEnvironment);

        if (_serverRuntimeEnvironments.Any(x => x.Server == server && x.RuntimeEnvironment == runtimeEnvironment))
        {
            return;
        }

        _serverRuntimeEnvironments.Add(new ServerRuntimeEnvironmentAssignment(server, runtimeEnvironment));
    }

    public void DeployComponent(DeploymentRuntimeEnvironment runtimeEnvironment, IComponent component)
    {
        ValidateRuntimeEnvironment(runtimeEnvironment);
        ValidateComponent(component);

        if (_runtimeComponents.Any(x => x.RuntimeEnvironment == runtimeEnvironment && x.Component == component))
        {
            return;
        }

        _runtimeComponents.Add(new RuntimeComponentAssignment(runtimeEnvironment, component));
    }

    public List<DeploymentEnvironment> GetEnvironments()
    {
        return _environments.ToList();
    }

    public List<DeploymentServer> GetServers(DeploymentEnvironment environment)
    {
        ValidateEnvironment(environment);

        return _environmentServers
            .Where(x => x.Environment == environment)
            .Select(x => x.Server)
            .Distinct()
            .ToList();
    }

    public List<DeploymentRuntimeEnvironment> GetRuntimeEnvironments(DeploymentServer server)
    {
        ValidateServer(server);

        return _serverRuntimeEnvironments
            .Where(x => x.Server == server)
            .Select(x => x.RuntimeEnvironment)
            .Distinct()
            .ToList();
    }

    public List<IComponent> GetComponents(DeploymentRuntimeEnvironment runtimeEnvironment)
    {
        ValidateRuntimeEnvironment(runtimeEnvironment);

        return _runtimeComponents
            .Where(x => x.RuntimeEnvironment == runtimeEnvironment)
            .Select(x => x.Component)
            .Distinct()
            .ToList();
    }

    public DeploymentEnvironment? GetEnvironment(DeploymentServer server)
    {
        ValidateServer(server);

        return _environmentServers
            .FirstOrDefault(x => x.Server == server)?.Environment;
    }

    public DeploymentServer? GetServer(DeploymentRuntimeEnvironment runtimeEnvironment)
    {
        ValidateRuntimeEnvironment(runtimeEnvironment);

        return _serverRuntimeEnvironments
            .FirstOrDefault(x => x.RuntimeEnvironment == runtimeEnvironment)?.Server;
    }

    private static TElement GetElement<TElement>(IEnumerable<TElement> elements, Type type) where TElement : class
    {
        var element = elements.SingleOrDefault(x => x != null && x.GetType() == type);

        if (element == null)
        {
            throw new Exception($"Element of type {type.FullName} is not defined in the model");
        }

        return element;
    }

    private void ValidateEnvironment(DeploymentEnvironment environment)
    {
        if (!_environments.Contains(environment))
        {
            throw new Exception($"Environment '{environment.Name}' is not registered in the model");
        }
    }

    private void ValidateServer(DeploymentServer server)
    {
        if (!_servers.Contains(server))
        {
            throw new Exception($"Server '{server.Name}' is not registered in the model");
        }
    }

    private void ValidateRuntimeEnvironment(DeploymentRuntimeEnvironment runtimeEnvironment)
    {
        if (!_runtimeEnvironments.Contains(runtimeEnvironment))
        {
            throw new Exception($"Runtime environment '{runtimeEnvironment.Name}' is not registered in the model");
        }
    }

    private void ValidateComponent(IComponent component)
    {
        if (!_components.Contains(component))
        {
            throw new Exception($"Component '{component.Name}' is not registered in the model");
        }
    }

    private record EnvironmentServerAssignment(DeploymentEnvironment Environment, DeploymentServer Server);

    private record ServerRuntimeEnvironmentAssignment(DeploymentServer Server, DeploymentRuntimeEnvironment RuntimeEnvironment);

    private record RuntimeComponentAssignment(DeploymentRuntimeEnvironment RuntimeEnvironment, IComponent Component);
}
