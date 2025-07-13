namespace Models.Elements;

public abstract class Element : IElement
{
    protected Element(string name)
    {
        Name = name;
        
        Id = $"{GetType().Name}_{name}";
    }

    public string Name { get; }
    
    public string Id { get; }
}