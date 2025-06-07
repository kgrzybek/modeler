namespace Modeler.ComponentsModel.Views.Markdown.Details;

public class MarkdownComponentDetailsView
{
    public MarkdownComponentDetailsView(string id, Component component)
    {
        Component = component;
        Id = id;
    }

    public Component Component { get; }
    public string Id { get; }
}

public abstract class MarkdownComponentDetailsViewDefinition
{
}
