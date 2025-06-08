namespace Modeler.RestApiModel;

public class ModelType : AttributeType
{
    public ApiModel Model { get; }

    private ModelType(ApiModel model) : base(model.Name)
    {
        Model = model;
    }

    public static AttributeType Create(ApiModel model) => new ModelType(model);
}
