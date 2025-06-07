namespace Modeler.RestApiModel.Views.AsciiDoc;

public class AsciiDocApiModelsView
{
    public AsciiDocApiModelsView(string id, Model model)
    {
        Id = id;
        Model = model;
    }

    public string Id { get; }

    public Model Model { get; }
}

public abstract class AsciiDocApiModelsViewDefinition
{
}
