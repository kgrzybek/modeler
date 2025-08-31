using Modeler.Models.Common;
using Modeler.Views.Common;

namespace Modeler.Views.StateMachine.Table.AsciiDoc;

public abstract class StateMachineAsciiDocTableView : IView
{
    protected StateMachineAsciiDocTableView(Models.StateMachine.StateMachine stateMachine)
    {
        StateMachine = stateMachine;
    }

    public Models.StateMachine.StateMachine StateMachine { get; }
}