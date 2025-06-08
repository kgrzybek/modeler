namespace Modeler.RestApiModel;

public class BooleanType : AttributeType
{
    private BooleanType() : base("boolean") { }

    public static AttributeType Create() => new BooleanType();
}
