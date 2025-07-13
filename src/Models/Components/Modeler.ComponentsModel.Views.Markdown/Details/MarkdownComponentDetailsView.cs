namespace Modeler.ComponentsModel.Views.Markdown.Details;

public class MarkdownComponentDetailsView
{
    public MarkdownComponentDetailsView(string id, IComponent component)
    {
        Component = component;
        Id = id;
    }

    public IComponent Component { get; }
    public string Id { get; }
}

public abstract class MarkdownComponentDetailsViewDefinition
{
}
