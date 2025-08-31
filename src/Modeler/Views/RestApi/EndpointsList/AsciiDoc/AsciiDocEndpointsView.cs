using Models.Elements;

namespace Modeler.RestApiModel.Views.AsciiDoc;

public abstract class AsciiDocEndpointsView : IView
{
    protected AsciiDocEndpointsView(IApiModel model)
    {
        Model = model;
    }

    public IApiModel Model { get; }
}