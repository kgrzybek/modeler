using Modeler.StateModel.Sample.Models;
using Modeler.StateModel.Views.Markdown;

namespace Modeler.StateModel.Sample.Views.Markdown;

public class AbsenceStateMachineMarkdownTableViewDefinition : StateMachineMarkdownTableViewDefinition
{
    public const string Id = "AbsenceStateMachine";

    public static StateMachineMarkdownTableView Create(HRStateStateMachineModel stateMachineModel)
    {
        var view = new StateMachineMarkdownTableView(
            Id,
            stateMachineModel.GetStateMachine<StateMachine>());

        return view;
    }
}
