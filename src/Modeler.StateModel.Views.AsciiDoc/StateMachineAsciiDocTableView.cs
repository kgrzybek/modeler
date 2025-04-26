namespace Modeler.StateModel.Views.AsciiDoc;

public class StateMachineAsciiDocTableView
{
    public StateMachineAsciiDocTableView(string id, StateMachine stateMachine)
    {
        Id = id;
        StateMachine = stateMachine;
    }

    public string Id { get; }

    public StateMachine StateMachine { get; }
}