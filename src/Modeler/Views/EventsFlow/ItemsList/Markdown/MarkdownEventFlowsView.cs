using Modeler.EventsFlowModel;
using Models.Elements;

namespace Modeler.Views.EventsFlow.ItemsList.Markdown;

public abstract class MarkdownEventFlowsView : IView
{
    protected MarkdownEventFlowsView(Model model)
    {
        Model = model;
    }

    public Model Model { get; }
}
