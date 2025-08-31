using Modeler.RestApiModel;
using Models.Elements;

namespace Modeler.Views.RestApi.EndpointsList.AsciiDoc;

public abstract class AsciiDocEndpointsView : IView
{
    protected AsciiDocEndpointsView(IApiModel model)
    {
        Model = model;
    }

    public IApiModel Model { get; }
}