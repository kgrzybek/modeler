using Modeler.RestApiModel.Views.AsciiDoc;

namespace Modeler.Full.Sample.Apis.Views.AsciiDoc;

public class EndpointsAsciiDocViewDefinition
{
    public const string Id = "RestApiEndpoints";

    public static AsciiDocEndpointsView Create(HRRestApiModel apisRegistry)
    {
        return new AsciiDocEndpointsView(Id, apisRegistry);
    }
}
