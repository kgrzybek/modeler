using Modeler.Models.Activity;
using Modeler.Views.Common;

namespace Modeler.Views.Activity.Diagram.Shared;

public abstract class ActivityDiagramView : IView
{
    protected ActivityDiagramView(ActivityFlow flow)
    {
        Flow = flow;
    }

    public ActivityFlow Flow { get; }
}
