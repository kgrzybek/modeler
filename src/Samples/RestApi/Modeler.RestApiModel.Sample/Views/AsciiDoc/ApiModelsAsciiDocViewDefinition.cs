using Modeler.RestApiModel.Sample.Models;
using Modeler.RestApiModel.Views.AsciiDoc;

namespace Modeler.RestApiModel.Sample.Views.AsciiDoc;

public class ApiModelsAsciiDocViewDefinition : AsciiDocApiModelsViewDefinition
{
    public const string Id = "RestApiModels";

    public static AsciiDocApiModelsView Create(HRRestApiModel apisRegistry)
    {
        return new AsciiDocApiModelsView(Id, apisRegistry);
    }
}
