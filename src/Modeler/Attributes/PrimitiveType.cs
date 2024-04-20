namespace Modeler.Attributes;

public abstract class PrimitiveType : AttributeType
{
    protected PrimitiveType WithName(
        string name)
    {
        this.Name = name;

        return this;
    }
}