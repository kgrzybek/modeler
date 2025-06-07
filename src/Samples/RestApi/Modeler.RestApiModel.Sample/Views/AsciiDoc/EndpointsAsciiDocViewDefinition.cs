using Modeler.RestApiModel.Sample.Models;
using Modeler.RestApiModel.Views.AsciiDoc;

namespace Modeler.RestApiModel.Sample.Views.AsciiDoc;

public class EndpointsAsciiDocViewDefinition : AsciiDocEndpointsViewDefinition
{
    public const string Id = "RestApiEndpoints";

    public static AsciiDocEndpointsView Create(HRRestApiModel model)
    {
        return new AsciiDocEndpointsView(Id, model);
    }
}
