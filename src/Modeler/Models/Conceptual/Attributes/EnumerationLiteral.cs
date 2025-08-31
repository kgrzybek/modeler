namespace Modeler.Models.Conceptual.Attributes;

public class EnumerationLiteral
{
    public EnumerationLiteral(string value)
    {
        Value = value;
    }

    public string Value { get; }
}