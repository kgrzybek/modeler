namespace Models.Elements;

public class ViewsRegistryBase
{
    private List<IView> _views;
    
    protected ViewsRegistryBase()
    {
        _views = new List<IView>();
    }
    
    public void AddElement(IView view)
    {
        _views.Add(view);
    }
    
    public T GetModel<T>()
    {
        return _views.OfType<T>().Single();
    }
    
    public List<T> GetElements<T>()
    {
        return _views.OfType<T>().ToList();
    }
}