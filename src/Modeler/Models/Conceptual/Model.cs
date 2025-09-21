using System.Reflection;
using Modeler.Models.Common.Elements;
using Modeler.Models.Common.Models;
using Modeler.Models.Conceptual.Attributes;
using Modeler.Models.Conceptual.Relationships;
using Modeler.Models.Conceptual.Relationships.Associations;
using Modeler.Models.Conceptual.Relationships.Generalizations;

namespace Modeler.Models.Conceptual;

public abstract class Model : IModel
{
    private readonly List<Entity> _entities;

    private readonly List<AttributeType> _types;

    private readonly List<Relationship> _relationships;
    
    public AttributeType GetType<T>() where T: AttributeType
    {
        var type = _types.OfType<T>().SingleOrDefault();
        
        if (type == null)
        {
            throw new Exception($"Type {typeof(T)} is not defined in the model");
        }

        return type;
    }

    public List<Entity> GetEntities()
    {
        return _entities.ToList();
    }
    
    public Entity GetEntity<T>() where T: Entity
    {
        var type = _entities.OfType<T>().SingleOrDefault();
        
        if (type == null)
        {
            throw new Exception($"Type {typeof(T)} is not defined in the model");
        }

        return type;
    }
    
    public void AddAssociation(AssociationRelationship associationRelationship)
    {
        _relationships.Add(associationRelationship);
    }

    public void AddGeneralization(Entity general, Entity specific)
    {
        _relationships.Add(new GeneralizationRelationship(general, specific));
    }

    public List<AssociationRelationship> GetAssociations() => _relationships.OfType<AssociationRelationship>().ToList();
    
    public List<GeneralizationRelationship> GetGeneralizations() => _relationships.OfType<GeneralizationRelationship>().ToList();
    
    public List<Relationship> GetRelationships() => _relationships.ToList();

    public Entity? GetGeneralizationEntity(Entity entity)
    {
        var generalizationRelationship = GetGeneralizations().SingleOrDefault(x => Equals(x.Specific, entity));

        return generalizationRelationship?.General;
    }

    protected Model(ModelElementsRegistry elementsRegistry)
    {
        _entities = elementsRegistry.GetElements<Entity>();
        _types = new List<AttributeType>();
        _relationships = new List<Relationship>();
        RegisterTypes<PrimitiveType>();
        RegisterTypes<EnumerationType>();
        RegisterTypes<ComplexAttributeType>();
    }
    
    private void RegisterTypes<T>() where T: AttributeType
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
                _types.Add((T) entity!);
            }
        }
    }
}