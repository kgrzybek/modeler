using Modeler.RestApiModel.Views.AsciiDoc;

namespace Modeler.Full.Sample.Apis.Views.AsciiDoc;

public class ApiModelsAsciiDocViewDefinition : AsciiDocApiModelsViewDefinition
{
    public const string Id = "RestApiModels";

    public static AsciiDocApiModelsView Create(HRRestApiModel api)
    {
        return new AsciiDocApiModelsView(Id, api);
    }
}
