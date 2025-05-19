namespace Modeler.ConceptualModel.Attributes;

public class Attribute
{
    private Attribute(string name, AttributeType type, bool isRequired)
    {
        Name = name;
        Type = type;
        IsRequired = isRequired;
    }

    public static Attribute Create<T>(T type, string name, bool isRequired) where T: AttributeType
    {
        return new Attribute(name, type, isRequired);
    }

    public string Name { get; }
    
    public AttributeType Type { get; }
    
    public bool IsRequired { get; }
}