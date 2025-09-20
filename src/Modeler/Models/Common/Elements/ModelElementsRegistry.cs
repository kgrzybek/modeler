namespace Modeler.Models.Common.Elements;

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
    
    public T GetElement<T>() where T :  IElement
    {
        var model = _elements.OfType<T>().SingleOrDefault();

        if (model == null)
        {
            throw new Exception($"Model element of type {typeof(T).FullName} is not registered.");
        }

        return model;
    }
}