using Modeler.Full.Sample.State.Models;
using Modeler.StateModel;
using Modeler.StateModel.Views.AsciiDoc;

namespace Modeler.Full.Sample.State.Views.StateMachineTable.AsciiDoc;

public class AbsenceStateMachineAsciiDocTableViewDefinition : StateMachineAsciiDocTableView
{
    public const string Id = "AbsenceStateMachine";

    public AbsenceStateMachineAsciiDocTableViewDefinition(HRStateStateMachineModel stateMachineModel) : base(stateMachineModel.GetStateMachine<StateMachine>())
    {
    }
}