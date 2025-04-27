using System.Reflection;

namespace Modeler.ComponentsModel;

public abstract class Model
{
    private List<Component> _components;

    private readonly List<ComponentRelationship> _relationships;

    protected Model()
    {
        _components = new List<Component>();
        _relationships = new List<ComponentRelationship>();
        InitializeComponents();
        InitializeRelationshipsModels();
    }

    public Component GetComponent<T>() where T : Component
    {
        var type = GetComponent<T>(_components);

        if (type == null)
        {
            throw new Exception($"Type {typeof(T)} is not defined in the model");
        }

        return type;
    }

    private static Component? GetComponent<T>(List<Component> components) where T : Component
    {
        foreach (var component in components)
        {
            if (component is T)
            {
                return component;
            }

            if (component.SubComponents.Any())
            {
                var subComponent = GetComponent<T>(component.SubComponents);
                if (subComponent is T)
                {
                    return subComponent;
                }
            }
        }

        return null;
    }

    public void AddAssociationRelationship(Component source, Component target, string? name = null)
    {
        _relationships.Add(new AssociationComponentRelationship(source, target, name));
    }

    public void AddUsageRelationship(Component source, Component target)
    {
        _relationships.Add(new UsageComponentRelationship(source, target));
    }

    public void AddDependencyRelationship(Component source, Component target)
    {
        _relationships.Add(new DependencyComponentRelationship(source, target));
    }

    private void InitializeComponents()
    {
        var assembly = Assembly.GetAssembly(this.GetType())!;
        var types = assembly
            .GetTypes()
            .Where(t =>
                typeof(Component).IsAssignableFrom(t))
            .ToList();

        foreach (var type in types)
        {
            var staticMethod = type.GetMethod("Create", BindingFlags.Static | BindingFlags.Public);

            if (staticMethod != null)
            {
                var component = staticMethod.Invoke(null, null) as Component;
                _components.Add(component!);
            }
        }
    }

    private void InitializeRelationshipsModels()
    {
        var assembly = Assembly.GetAssembly(this.GetType())!;
        var types = assembly
            .GetTypes()
            .Where(t =>
                typeof(RelationshipsModel).IsAssignableFrom(t))
            .ToList();

        foreach (var type in types)
        {
            var staticMethod = type.GetMethod("Create", BindingFlags.Static | BindingFlags.Public);

            if (staticMethod != null)
            {
                staticMethod.Invoke(null, new object?[] {this});
            }
        }
    }

    public List<ComponentRelationship> GetRelationships() => _relationships.ToList();

    public List<ComponentType> GetComponentTypes()
    {
        var componentTypes = new List<ComponentType>();
        foreach (var component in _components)
        {
            componentTypes.AddRange(GetComponentTypes(component));
        }

        return componentTypes.Distinct().ToList();
    }

    public List<ComponentType> GetComponentTypes(Component component)
    {
        var componentTypes = new List<ComponentType>();
        componentTypes.Add(component.Type);

        foreach (var subComponent in component.SubComponents)
        {
            componentTypes.AddRange(GetComponentTypes(subComponent));
        }

        return componentTypes;
    }

    public List<Component> GetAllComponents()
    {
        var components = new List<Component>();
        foreach (var component in _components)
        {
            components.AddRange(GetAllComponents(component));
        }

        return components;
    }
    
    private static List<Component> GetAllComponents(Component component)
    {
        var components = new List<Component>();
        components.Add(component);
        foreach (var subComponent in component.SubComponents)
        {
            components.AddRange(GetAllComponents(subComponent));
        }

        return components;
    }
}