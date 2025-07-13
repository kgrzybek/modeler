using System.Reflection;

namespace Models.Elements;

public class ModelElementsRegistry
{
    private List<IElement> _elements;
    
    protected ModelElementsRegistry()
    {
        _elements = new List<IElement>();
    }
    
    public void AddElementsFromAssembly(Assembly assembly)
    {
        var types = assembly
            .GetTypes()
            .Where(t =>
                typeof(IElement).IsAssignableFrom(t))
            .ToList();

        foreach (var type in types)
        {
            var staticMethod = type.GetMethod("Create", BindingFlags.Static | BindingFlags.Public);

            if (staticMethod != null)
            {
                var element = staticMethod.Invoke(null, null) as IElement;
                _elements.Add(element!);
            }
        }
    }

    public List<T> GetElements<T>()
    {
        return _elements.OfType<T>().ToList();
    }
}