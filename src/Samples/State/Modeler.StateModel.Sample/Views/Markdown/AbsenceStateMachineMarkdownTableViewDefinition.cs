using Modeler.StateModel.Sample.Models;
using Modeler.StateModel.Views.Markdown;

namespace Modeler.StateModel.Sample.Views.Markdown;

public class AbsenceStateMachineMarkdownTableViewDefinition : StateMachineMarkdownTableViewDefinition
{
    public const string Id = "AbsenceStateMachine";

    public static StateMachineMarkdownTableView Create(HRStateModel model)
    {
        var view = new StateMachineMarkdownTableView(
            Id,
            model.GetStateMachine<StateMachine>());

        return view;
    }
}
