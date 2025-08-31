using Models.Elements;

namespace Modeler.EventsFlowModel.Views.Markdown;

public abstract class MarkdownEventFlowsView : IView
{
    protected MarkdownEventFlowsView(Model model)
    {
        Model = model;
    }

    public Model Model { get; }
}
