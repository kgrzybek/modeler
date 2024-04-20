namespace Modeler.Attributes;

public abstract class EnumerationType : AttributeType
{
    public List<EnumerationLiteral> Values { get; private set; }

    protected EnumerationType()
    {
        Values = new List<EnumerationLiteral>();
    }
    
    protected EnumerationType WithName(
        string name)
    {
        this.Name = name;

        return this;
    }

    public EnumerationType WithValues(params string[] values)
    {
        Values = values.Select(x => new EnumerationLiteral(x)).ToList();

        return this;
    }
}