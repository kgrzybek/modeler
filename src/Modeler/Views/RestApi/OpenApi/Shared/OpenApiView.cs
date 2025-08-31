using Modeler.Models.Common;
using Modeler.Models.RestApi;
using Modeler.Views.Common;

namespace Modeler.Views.RestApi.OpenApi.Shared;

public abstract class OpenApiView : IView
{
    protected OpenApiView(IApiModel model)
    {
        Model = model;
    }

    public IApiModel Model { get; }
}