using Modeler.RestApiModel;
using Modeler.Views.RestApi.ApiModelsList.AsciiDoc;

namespace Modeler.Full.Sample.Apis.Views.AsciiDoc;

public class ApiModelsAsciiDocViewDefinition : AsciiDocApiModelsView
{
    public const string Id = "RestApiModels";

    public ApiModelsAsciiDocViewDefinition(IApiModel model) : base(model)
    {
    }
}
