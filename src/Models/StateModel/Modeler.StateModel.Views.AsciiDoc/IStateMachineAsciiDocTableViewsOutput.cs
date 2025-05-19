namespace Modeler.StateModel.Views.AsciiDoc;

public interface IStateMachineAsciiDocTableViewsOutput<T>
{
    public void Execute(List<StateMachineAsciiDocTableViewsOutputItem<T>> views);
}

public record StateMachineAsciiDocTableViewsOutputItem<T>(string Id, T View, string Content);