using Modeler.RestApiModel.Views.OpenApi;

namespace Modeler.Full.Sample.Apis.Views.OpenApi;

public class OpenApiYamlViewDefinition : OpenApiViewDefinition
{
    public const string Id = "RestApiOpenApiYaml";

    public static OpenApiView Create(HRRestApiModel apisRegistry)
    {
        return new OpenApiView(Id, apisRegistry);
    }
}
