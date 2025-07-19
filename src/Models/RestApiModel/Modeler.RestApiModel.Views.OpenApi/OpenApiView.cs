namespace Modeler.RestApiModel.Views.OpenApi;

public class OpenApiView
{
    public OpenApiView(string id, IApiModel model)
    {
        Id = id;
        Model = model;
    }

    public string Id { get; }

    public IApiModel Model { get; }
}

public abstract class OpenApiViewDefinition
{
}
