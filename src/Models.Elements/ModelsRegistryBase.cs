namespace Models.Elements;

public class ModelsRegistryBase
{
    private readonly List<IModel> _models;
    
    protected ModelsRegistryBase()
    {
        _models = new List<IModel>();
    }

    protected void AddElement(IModel model)
    {
        _models.Add(model);
    }
    
    public T GetModel<T>()
    {
        return _models.OfType<T>().Single();
    }
}