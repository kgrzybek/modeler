namespace Modeler.Models.Common.Elements;

public abstract class Element : IElement
{
    protected Element(string name)
    {
        Name = name;
        
        Id = $"{GetType().Name}";
    }

    public string Name { get; }
    
    public string Id { get; }
}