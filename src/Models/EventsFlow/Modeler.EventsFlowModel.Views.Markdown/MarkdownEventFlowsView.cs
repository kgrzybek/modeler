namespace Modeler.EventsFlowModel.Views.Markdown;

public class MarkdownEventFlowsView
{
    public MarkdownEventFlowsView(string id, Model model)
    {
        Id = id;
        Model = model;
    }

    public string Id { get; }

    public Model Model { get; }
}

public abstract class MarkdownEventFlowsViewDefinition
{
}
