namespace Modeler.Models.RestApi.Types;

public class NumberType : AttributeType
{
    private NumberType() : base("number") { }

    public static AttributeType Create() => new NumberType();
}
