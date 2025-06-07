namespace Modeler.RestApiModel.Views.OpenApi;

public class OpenApiView
{
    public OpenApiView(string id, Model model)
    {
        Id = id;
        Model = model;
    }

    public string Id { get; }

    public Model Model { get; }
}

public abstract class OpenApiViewDefinition
{
}
