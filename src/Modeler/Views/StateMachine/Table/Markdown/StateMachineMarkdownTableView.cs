using Modeler.Models.Common;
using Modeler.Views.Common;

namespace Modeler.Views.StateMachine.Table.Markdown;

public abstract class StateMachineMarkdownTableView : IView
{
    protected StateMachineMarkdownTableView(Models.StateMachine.StateMachine stateMachine)
    {
        StateMachine = stateMachine;
    }

    public Models.StateMachine.StateMachine StateMachine { get; }
}