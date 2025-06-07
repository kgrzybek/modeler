namespace Modeler.StateModel.Views.Markdown;

public interface IStateMachineMarkdownTableViewsOutput<T>
{
    void Execute(List<StateMachineMarkdownTableViewsOutputItem<T>> views);
}

public record StateMachineMarkdownTableViewsOutputItem<T>(string Id, T View, string Content);
