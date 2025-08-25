using Models.Elements;

namespace Modeler.RestApiModel.Views.AsciiDoc;

public class AsciiDocApiModelsView : IView
{
    public AsciiDocApiModelsView(string id, IApiModel model)
    {
        Id = id;
        Model = model;
    }

    public string Id { get; }

    public IApiModel Model { get; }
}

public abstract class AsciiDocApiModelsViewDefinition
{
}
