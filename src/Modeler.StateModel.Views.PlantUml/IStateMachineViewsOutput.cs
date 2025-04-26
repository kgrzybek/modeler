namespace Modeler.StateModel.Views.PlantUml;

public interface IStateMachineViewsOutput<T>
{
    public void Execute(List<StateMachineViewOutputItem<T>> views);
}

public record StateMachineViewOutputItem<T>(string Id, T View, string Content);