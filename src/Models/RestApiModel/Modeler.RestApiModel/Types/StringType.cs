namespace Modeler.RestApiModel;

public class StringType : AttributeType
{
    private StringType() : base("string") { }

    public static AttributeType Create() => new StringType();
}
