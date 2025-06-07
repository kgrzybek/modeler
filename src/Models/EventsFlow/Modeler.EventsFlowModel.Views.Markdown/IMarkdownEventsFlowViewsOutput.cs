namespace Modeler.EventsFlowModel.Views.Markdown;

public interface IMarkdownEventsFlowViewsOutput<T>
{
    void Execute(List<MarkdownEventsFlowViewsOutputItem<T>> views);
}

public record MarkdownEventsFlowViewsOutputItem<T>(string Id, T View, string Content);
