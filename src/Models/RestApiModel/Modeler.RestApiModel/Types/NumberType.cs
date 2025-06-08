namespace Modeler.RestApiModel;

public class NumberType : AttributeType
{
    private NumberType() : base("number") { }

    public static AttributeType Create() => new NumberType();
}
