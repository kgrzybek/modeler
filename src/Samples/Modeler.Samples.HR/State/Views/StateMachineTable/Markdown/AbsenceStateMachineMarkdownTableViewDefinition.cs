using Modeler.Models.StateMachine;
using Modeler.Samples.HR.State.Models;
using Modeler.Views.StateMachine.Table.Markdown;

namespace Modeler.Samples.HR.State.Views.StateMachineTable.Markdown;

public class AbsenceStateMachineMarkdownTableViewDefinition : StateMachineMarkdownTableView
{
    public AbsenceStateMachineMarkdownTableViewDefinition(HRStateStateMachineModel stateMachineModel) : base(stateMachineModel.GetStateMachine<StateMachine>())
    {
    }
}
