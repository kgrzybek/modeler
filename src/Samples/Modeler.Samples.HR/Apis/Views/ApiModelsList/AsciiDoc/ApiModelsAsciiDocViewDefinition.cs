using Modeler.Models.RestApi;
using Modeler.Views.RestApi.ApiModelsList.AsciiDoc;

namespace Modeler.Samples.HR.Apis.Views.AsciiDoc;

public class ApiModelsAsciiDocViewDefinition : AsciiDocApiModelsView
{
    public const string Id = "RestApiModels";

    public ApiModelsAsciiDocViewDefinition(IApiModel model) : base(model)
    {
    }
}
