using Modeler.RestApiModel.Sample.Models;
using Modeler.RestApiModel.Views.OpenApi;

namespace Modeler.RestApiModel.Sample.Views.OpenApi;

public class OpenApiJsonViewDefinition : OpenApiViewDefinition
{
    public const string Id = "RestApiOpenApi";

    public static OpenApiView Create(HRRestApiModel model)
    {
        return new OpenApiView(Id, model);
    }
}
