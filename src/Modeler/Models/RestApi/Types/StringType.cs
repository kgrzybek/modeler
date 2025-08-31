namespace Modeler.Models.RestApi.Types;

public class StringType : AttributeType
{
    private StringType() : base("string") { }

    public static AttributeType Create() => new StringType();
}
