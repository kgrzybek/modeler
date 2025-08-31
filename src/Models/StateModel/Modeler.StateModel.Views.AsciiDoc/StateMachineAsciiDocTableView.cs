using Models.Elements;

namespace Modeler.StateModel.Views.AsciiDoc;

public abstract class StateMachineAsciiDocTableView : IView
{
    protected StateMachineAsciiDocTableView(StateMachine stateMachine)
    {
        StateMachine = stateMachine;
    }

    public StateMachine StateMachine { get; }
}