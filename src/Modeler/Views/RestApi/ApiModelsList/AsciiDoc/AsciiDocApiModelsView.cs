using Modeler.RestApiModel;
using Models.Elements;

namespace Modeler.Views.RestApi.ApiModelsList.AsciiDoc;

public abstract class AsciiDocApiModelsView : IView
{
    public AsciiDocApiModelsView(IApiModel model)
    {
        Model = model;
    }

    public IApiModel Model { get; }
}
