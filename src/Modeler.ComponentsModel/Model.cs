using System.Reflection;

namespace Modeler.ComponentsModel;

public abstract class Model
{
    private List<Component> _components;

    private readonly List<ComponentRelationship> _relationships;
    
    private readonly List<ComponentType> _componentTypes;

    protected Model()
    {
        _components = new List<Component>();
        _relationships = new List<ComponentRelationship>();
        _componentTypes = new List<ComponentType>();
        RegisterTypes<ComponentType>();
        InitializeComponents();
        InitializeRelationshipsModels();
    }
    
    public List<Component> GetComponents() => _components.ToList();
    
    public Component GetComponent<T>() where T: Component
    {
        var type = GetComponent<T>(_components);
        
        if (type == null)
        {
            throw new Exception($"Type {typeof(T)} is not defined in the model");
        }

        return type;
    }

    private static Component? GetComponent<T>(List<Component> components) where T: Component
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

    public void AddComponent(Component component)
    {
        _components.Add(component);
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
                staticMethod.Invoke(null, new object?[]{ this });
            }
        }
    }
    
    private void RegisterTypes<T>() where T: ComponentType
    {
        var assembly = Assembly.GetAssembly(this.GetType());
        
        var types = assembly!
            .GetTypes()
            .Where(t =>
                typeof(T).IsAssignableFrom(t))
            .ToList();
        
        foreach (var type in types)
        {
            var staticMethod = type.GetMethod("Create", BindingFlags.Static | BindingFlags.Public);

            if (staticMethod != null)
            {
                var entity = staticMethod.Invoke(null, null);
                _componentTypes.Add((T) entity!);
            }
        }
    }
    public List<ComponentRelationship> GetRelationships() => _relationships.ToList();
}