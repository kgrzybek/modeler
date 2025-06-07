namespace Modeler.EventsFlowModel.Views.AsciiDoc;

public interface IAsciiDocEventsFlowViewsOutput<T>
{
    void Execute(List<AsciiDocEventsFlowViewsOutputItem<T>> views);
}

public record AsciiDocEventsFlowViewsOutputItem<T>(string Id, T View, string Content);
