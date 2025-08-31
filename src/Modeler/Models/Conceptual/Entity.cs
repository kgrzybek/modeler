using Modeler.Models.Common.Elements;
using Modeler.Models.Conceptual.Attributes;
using Attribute = Modeler.Models.Conceptual.Attributes.Attribute;

namespace Modeler.Models.Conceptual;

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

        this.Id = ElementIdGenerator.GenerateElementId(this.GetType(), name);

        return this;
    }
}