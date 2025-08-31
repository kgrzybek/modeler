using Models.Elements;

namespace Modeler.Views.StateMachine.Table.Markdown;

public abstract class StateMachineMarkdownTableView : IView
{
    protected StateMachineMarkdownTableView(StateModel.StateMachine stateMachine)
    {
        StateMachine = stateMachine;
    }

    public StateModel.StateMachine StateMachine { get; }
}