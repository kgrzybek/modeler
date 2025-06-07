using Modeler.EventsFlowModel.Views.Markdown;

namespace Modeler.EventsFlowModel.Sample.Views.Markdown;

public class HREventsFlowMarkdownViewDefinition : MarkdownEventFlowsViewDefinition
{
    public const string Id = "HREventsFlowMarkdown";

    public static MarkdownEventFlowsView Create(HREventsFlowModel model)
    {
        var view = new MarkdownEventFlowsView(Id, model);
        return view;
    }
}
