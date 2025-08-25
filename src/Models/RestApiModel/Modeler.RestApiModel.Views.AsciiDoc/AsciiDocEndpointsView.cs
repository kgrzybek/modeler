using Models.Elements;

namespace Modeler.RestApiModel.Views.AsciiDoc;

public class AsciiDocEndpointsView : IView
{
    public AsciiDocEndpointsView(string id, IApiModel model)
    {
        Id = id;
        Model = model;
    }

    public string Id { get; }

    public IApiModel Model { get; }
}