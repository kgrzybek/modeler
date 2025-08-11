using Models.Elements;

namespace Modeler.StateModel.Views.AsciiDoc;

public class StateMachineAsciiDocTableView : IView
{
    public StateMachineAsciiDocTableView(string id, StateMachine stateMachine)
    {
        Id = id;
        StateMachine = stateMachine;
    }

    public string Id { get; }

    public StateMachine StateMachine { get; }
}