using Models.Elements;

namespace Modeler.EventsFlowModel.Views.Markdown;

public class MarkdownEventFlowsView : IView
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
