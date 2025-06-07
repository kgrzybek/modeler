namespace Modeler.StateModel.Views.Markdown;

public class StateMachineMarkdownTableView
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
