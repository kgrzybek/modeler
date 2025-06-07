using Modeler.EventsFlowModel.Views.AsciiDoc;

namespace Modeler.EventsFlowModel.Sample.Views.AsciiDoc;

public class HREventsFlowAsciiDocViewDefinition : AsciiDocEventFlowsViewDefinition
{
    public const string Id = "HREventsFlowAsciiDoc";

    public static AsciiDocEventFlowsView Create(HREventsFlowModel model)
    {
        var view = new AsciiDocEventFlowsView(Id, model);
        return view;
    }
}
