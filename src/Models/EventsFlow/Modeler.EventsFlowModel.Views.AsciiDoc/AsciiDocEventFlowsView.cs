using Models.Elements;

namespace Modeler.EventsFlowModel.Views.AsciiDoc;

public abstract class AsciiDocEventFlowsView : IView
{
    protected AsciiDocEventFlowsView(Model model)
    {
        Model = model;
    }

    public Model Model { get; }
}
