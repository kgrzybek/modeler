using Modeler.Models.Common.Elements;
using Modeler.Models.Common.Models;

namespace Modeler.Models.Components;

public abstract class Model : IModel
{
    private List<IComponent> _components;

    private readonly List<ComponentRelationship> _relationships;

    protected Model(ModelElementsRegistry elementsRegistry)
    {
        _components = elementsRegistry.GetElements<IComponent>();
        _relationships = new List<ComponentRelationship>();
    }

    public IComponent GetComponent<T>() where T : IComponent
    {
        var type = _components.Single(x => x.GetType() == typeof(T));

        if (type == null)
        {
            throw new Exception($"Type {typeof(T)} is not defined in the model");
        }

        return type;
    }

    private static IComponent? GetComponent<T>(List<IComponent> components) where T : IComponent
    {
        foreach (var component in components)
        {
            if (component is T)
            {
                return component;
            }
        }

        return null;
    }

    public void AddAssociationRelationship(Component source, Component target, string? name = null)
    {
        _relationships.Add(new AssociationComponentRelationship(source, target, name));
    }

    public void AddUsageRelationship(IComponent source, IComponent target)
    {
        _relationships.Add(new UsageComponentRelationship(source, target));
    }

    public void AddDependencyRelationship(IComponent source, IComponent target)
    {
        _relationships.Add(new DependencyComponentRelationship(source, target));
    }
    
    public void AddContainsRelationship(IComponent source, IComponent target)
    {
        _relationships.Add(new ContainsComponentRelationship(source, target));
    }

    public List<ComponentRelationship> GetRelationships() => _relationships.ToList();

    public List<ComponentRelationship> GetComponentRelationships(IComponent component)
    {
        var relationships = new List<ComponentRelationship>();
        
        relationships.AddRange(_relationships
            .Where(x => x.Source == component || x.Target == component).ToList());

        var subComponents = GetSubComponents(component);

        foreach (var subComponent in subComponents)
        {
            var subComponentRelationships = GetComponentRelationships(subComponent);
            relationships.AddRange(subComponentRelationships);
        }
        
        return relationships.Distinct().ToList();
    }

    public bool Contains(IComponent component, IComponent childComponent)
    {
        return _relationships.Any(x => x.Source == component && x.Target == childComponent);
    }

    public List<ComponentType> GetComponentTypes()
    {
        return _components.Select(x => x.Type).Distinct().ToList();
    }

    public List<IComponent> GetAllComponents()
    {
        return _components;
    }

    public List<IComponent> GetSubComponents(IComponent component)
    {
        return _relationships.OfType<ContainsComponentRelationship>().Where(x => x.Source == component)
            .Select(x => x.Target)
            .ToList();
    }
    
    public List<IComponent> GetAllSubComponents(IComponent component)
    {
        List<IComponent> allComponents = new List<IComponent>();
        var subComponents =  GetSubComponents(component);
        allComponents.AddRange(subComponents);

        foreach (var subComponent in subComponents)
        {
            var allSubComponents = GetAllSubComponents(subComponent);
            allComponents.AddRange(allSubComponents);
        }

        return allComponents.Distinct().ToList();
    }
}