using Modeler.Models.Common;
using Modeler.Models.RestApi;
using Modeler.Views.Common;

namespace Modeler.Views.RestApi.EndpointsList.AsciiDoc;

public abstract class AsciiDocEndpointsView : IView
{
    protected AsciiDocEndpointsView(IApiModel model)
    {
        Model = model;
    }

    public IApiModel Model { get; }
}