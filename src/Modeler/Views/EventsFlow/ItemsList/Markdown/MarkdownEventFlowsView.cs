using Modeler.Models.Common;
using Modeler.Models.EventsFlow;
using Modeler.Views.Common;

namespace Modeler.Views.EventsFlow.ItemsList.Markdown;

public abstract class MarkdownEventFlowsView : IView
{
    protected MarkdownEventFlowsView(Model model)
    {
        Model = model;
    }

    public Model Model { get; }
}
