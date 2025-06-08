namespace Modeler.RestApiModel;

public class IntegerType : AttributeType
{
    private IntegerType() : base("integer") { }

    public static AttributeType Create() => new IntegerType();
}
