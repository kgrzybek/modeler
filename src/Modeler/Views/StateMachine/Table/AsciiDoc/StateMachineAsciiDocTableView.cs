using Models.Elements;

namespace Modeler.Views.StateMachine.Table.AsciiDoc;

public abstract class StateMachineAsciiDocTableView : IView
{
    protected StateMachineAsciiDocTableView(StateModel.StateMachine stateMachine)
    {
        StateMachine = stateMachine;
    }

    public StateModel.StateMachine StateMachine { get; }
}