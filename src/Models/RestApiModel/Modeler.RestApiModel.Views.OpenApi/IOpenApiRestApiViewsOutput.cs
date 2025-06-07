namespace Modeler.RestApiModel.Views.OpenApi;

public interface IOpenApiRestApiViewsOutput<T>
{
    void Execute(List<OpenApiRestApiViewsOutputItem<T>> views);
}

public record OpenApiRestApiViewsOutputItem<T>(string Id, T View, string Content);
