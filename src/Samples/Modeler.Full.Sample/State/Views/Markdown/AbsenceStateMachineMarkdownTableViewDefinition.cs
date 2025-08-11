using Modeler.Full.Sample.State.Models;
using Modeler.StateModel;
using Modeler.StateModel.Views.Markdown;

namespace Modeler.Full.Sample.State.Views.Markdown;

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
