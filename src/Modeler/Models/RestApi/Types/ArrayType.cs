namespace Modeler.RestApiModel.Types;

public class ArrayType : AttributeType
{
    public AttributeType ElementType { get; }

    private ArrayType(AttributeType elementType) : base($"{elementType.Name}[]")
    {
        ElementType = elementType;
    }

    public static AttributeType Create(AttributeType elementType) => new ArrayType(elementType);
}
