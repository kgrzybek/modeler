namespace Models.Elements;

public class ModelsRegistryBase
{
    private List<IModel> _models;
    
    protected ModelsRegistryBase()
    {
        _models = new List<IModel>();
    }
    
    public void AddElement(IModel model)
    {
        _models.Add(model);
    }
    
    public T GetModel<T>()
    {
        return _models.OfType<T>().Single();
    }
}