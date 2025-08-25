using Modeler.Full.Sample.State.Models;
using Modeler.StateModel;
using Modeler.StateModel.Views.Markdown;

namespace Modeler.Full.Sample.State.Views.Markdown;

public class AbsenceStateMachineMarkdownTableViewDefinition
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
