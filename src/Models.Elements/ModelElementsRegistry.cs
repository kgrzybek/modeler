namespace Models.Elements;

public class ModelElementsRegistry
{
    private readonly List<IElement> _elements;
    
    protected ModelElementsRegistry()
    {
        _elements = new List<IElement>();
    }

    public List<T> GetElements<T>()
    {
        return _elements.OfType<T>().ToList();
    }

    public void AddElement(IElement element)
    {
        _elements.Add(element);
    }
    
    public T GetElement<T>()
    {
        return _elements.OfType<T>().Single();
    }
}