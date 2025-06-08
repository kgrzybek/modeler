namespace Modeler.RestApiModel.Types;

public class NumberType : AttributeType
{
    private NumberType() : base("number") { }

    public static AttributeType Create() => new NumberType();
}
