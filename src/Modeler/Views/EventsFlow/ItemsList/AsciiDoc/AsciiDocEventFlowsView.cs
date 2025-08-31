using Modeler.EventsFlowModel;
using Models.Elements;

namespace Modeler.Views.EventsFlow.ItemsList.AsciiDoc;

public abstract class AsciiDocEventFlowsView : IView
{
    protected AsciiDocEventFlowsView(Model model)
    {
        Model = model;
    }

    public Model Model { get; }
}
