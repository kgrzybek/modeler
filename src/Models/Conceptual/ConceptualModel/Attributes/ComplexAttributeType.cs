namespace Modeler.ConceptualModel.Attributes;

public abstract class ComplexAttributeType : AttributeType
{
    public List<Attribute> Attributes { get; } = new List<Attribute>();

    public ComplexAttributeType WithAttribute(
        string name,
        AttributeType type,
        bool isRequired = true)
    {
        Attributes.Add(Attribute.Create(type, name, isRequired));

        return this;
    }
    
    protected ComplexAttributeType WithName(
        string name)
    {
        this.Name = name;

        return this;
    }
}