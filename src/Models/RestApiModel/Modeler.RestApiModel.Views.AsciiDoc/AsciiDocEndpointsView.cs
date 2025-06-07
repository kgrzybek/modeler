namespace Modeler.RestApiModel.Views.AsciiDoc;

public class AsciiDocEndpointsView
{
    public AsciiDocEndpointsView(string id, Model model)
    {
        Id = id;
        Model = model;
    }

    public string Id { get; }

    public Model Model { get; }
}

public abstract class AsciiDocEndpointsViewDefinition
{
}
