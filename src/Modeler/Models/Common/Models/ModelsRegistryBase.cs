namespace Modeler.Models.Common.Models;

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
    
    public T GetModel<T>() where T: IModel
    {
        return _models.OfType<T>().Single();
    }
}