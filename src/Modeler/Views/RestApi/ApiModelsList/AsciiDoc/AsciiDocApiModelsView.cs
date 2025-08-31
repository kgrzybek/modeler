using Modeler.Models.Common;
using Modeler.Models.RestApi;
using Modeler.Views.Common;

namespace Modeler.Views.RestApi.ApiModelsList.AsciiDoc;

public abstract class AsciiDocApiModelsView : IView
{
    public AsciiDocApiModelsView(IApiModel model)
    {
        Model = model;
    }

    public IApiModel Model { get; }
}
