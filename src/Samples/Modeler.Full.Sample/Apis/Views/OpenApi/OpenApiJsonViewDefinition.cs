using Modeler.RestApiModel.Views.OpenApi;

namespace Modeler.Full.Sample.Apis.Views.OpenApi;

public class OpenApiJsonViewDefinition : OpenApiViewDefinition
{
    public const string Id = "RestApiOpenApi";

    public static OpenApiView Create(HRRestApiModel apisRegistry)
    {
        return new OpenApiView(Id, apisRegistry);
    }
}
