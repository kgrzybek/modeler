using Modeler.Models.Common;
using Modeler.Models.EventsFlow;
using Modeler.Views.Common;

namespace Modeler.Views.EventsFlow.ItemsList.AsciiDoc;

public abstract class AsciiDocEventFlowsView : IView
{
    protected AsciiDocEventFlowsView(Model model)
    {
        Model = model;
    }

    public Model Model { get; }
}
