namespace Modeler.Attributes;

public abstract class AttributeType : Concept
{
    protected AttributeType()
    {
        
    }
    
    protected AttributeType(string name)
    {
        Name = name;
    }
}