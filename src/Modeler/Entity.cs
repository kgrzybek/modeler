using Modeler.Attributes;
using Attribute = Modeler.Attributes.Attribute;

namespace Modeler;

public abstract class Entity : Concept
{
    public List<Attribute> Attributes { get; } = new List<Attribute>();

    public Entity WithAttribute(string name, AttributeType type, bool isRequired = true)
    {
        Attributes.Add(Attribute.Create(type, name, isRequired));
        
        return this;
    }
    
    protected Entity WithName(
        string name)
    {
        this.Name = name;

        return this;
    }
}