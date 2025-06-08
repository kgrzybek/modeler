using Modeler.RestApiModel.Sample.Models;
using Modeler.RestApiModel.Views.OpenApi;

namespace Modeler.RestApiModel.Sample.Views.OpenApi;

public class OpenApiYamlViewDefinition : OpenApiViewDefinition
{
    public const string Id = "RestApiOpenApiYaml";

    public static OpenApiView Create(HRRestApiModel model)
    {
        return new OpenApiView(Id, model);
    }
}
