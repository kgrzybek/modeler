using Modeler.Full.Sample.State.Models;
using Modeler.StateModel;
using Modeler.Views.StateMachine.Table.Markdown;

namespace Modeler.Full.Sample.State.Views.StateMachineTable.Markdown;

public class AbsenceStateMachineMarkdownTableViewDefinition : StateMachineMarkdownTableView
{
    public AbsenceStateMachineMarkdownTableViewDefinition(HRStateStateMachineModel stateMachineModel) : base(stateMachineModel.GetStateMachine<StateMachine>())
    {
    }
}
