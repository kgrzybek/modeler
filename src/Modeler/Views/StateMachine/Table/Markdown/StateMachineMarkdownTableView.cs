using Models.Elements;

namespace Modeler.StateModel.Views.Markdown;

public abstract class StateMachineMarkdownTableView : IView
{
    protected StateMachineMarkdownTableView(StateMachine stateMachine)
    {
        StateMachine = stateMachine;
    }

    public StateMachine StateMachine { get; }
}