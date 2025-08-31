using Modeler.Models.StateMachine;
using Modeler.Samples.HR.State.Models;
using Modeler.Views.StateMachine.Table.AsciiDoc;

namespace Modeler.Samples.HR.State.Views.StateMachineTable.AsciiDoc;

public class AbsenceStateMachineAsciiDocTableViewDefinition : StateMachineAsciiDocTableView
{
    public const string Id = "AbsenceStateMachine";

    public AbsenceStateMachineAsciiDocTableViewDefinition(HRStateStateMachineModel stateMachineModel) : base(stateMachineModel.GetStateMachine<StateMachine>())
    {
    }
}