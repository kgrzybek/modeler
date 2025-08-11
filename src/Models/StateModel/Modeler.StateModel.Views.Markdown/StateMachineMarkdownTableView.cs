using Models.Elements;

namespace Modeler.StateModel.Views.Markdown;

public class StateMachineMarkdownTableView : IView
{
    public StateMachineMarkdownTableView(string id, StateMachine stateMachine)
    {
        Id = id;
        StateMachine = stateMachine;
    }

    public string Id { get; }

    public StateMachine StateMachine { get; }
}

public abstract class StateMachineMarkdownTableViewDefinition
{
}
