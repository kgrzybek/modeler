using Modeler.RestApiModel;
using Models.Elements;

namespace Modeler.Views.RestApi.OpenApi.Shared;

public abstract class OpenApiView : IView
{
    protected OpenApiView(IApiModel model)
    {
        Model = model;
    }

    public IApiModel Model { get; }
}