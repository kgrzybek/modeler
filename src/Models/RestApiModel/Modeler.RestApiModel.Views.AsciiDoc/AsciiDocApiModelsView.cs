using Models.Elements;

namespace Modeler.RestApiModel.Views.AsciiDoc;

public abstract class AsciiDocApiModelsView : IView
{
    public AsciiDocApiModelsView(IApiModel model)
    {
        Model = model;
    }

    public IApiModel Model { get; }
}
