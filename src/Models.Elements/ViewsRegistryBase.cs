namespace Models.Elements;

public class ViewsRegistryBase
{
    private readonly List<IView> _views;
    
    protected ViewsRegistryBase()
    {
        _views = new List<IView>();
    }

    protected void AddElement(IView view)
    {
        _views.Add(view);
    }
    
    public List<T> GetElements<T>()
    {
        return _views.OfType<T>().ToList();
    }
}