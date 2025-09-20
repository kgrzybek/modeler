using Modeler.Models.RestApi;
using Modeler.Views.RestApi.ApiModelsList.AsciiDoc;

namespace Modeler.Samples.HR.Components.System.Backend.Modules.Api.Views.ApiModelsList.AsciiDoc;

public class ApiModelsAsciiDocViewDefinition : AsciiDocApiModelsView
{
    public const string Id = "RestApiModels";

    public ApiModelsAsciiDocViewDefinition(IApiModel model) : base(model)
    {
    }
}
