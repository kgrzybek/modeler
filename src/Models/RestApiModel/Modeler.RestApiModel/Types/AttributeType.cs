namespace Modeler.RestApiModel;

public abstract class AttributeType
{
    public string Name { get; }

    protected AttributeType(string name)
    {
        Name = name;
    }

    public override string ToString() => Name;
}
