namespace Modeler.RestApiModel.Types;

public class ModelType : AttributeType
{
    public ApiObjectModel ObjectModel { get; }

    private ModelType(ApiObjectModel objectModel) : base(objectModel.Name)
    {
        ObjectModel = objectModel;
    }

    public static AttributeType Create(ApiObjectModel objectModel) => new ModelType(objectModel);
}
