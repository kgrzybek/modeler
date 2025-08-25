using Modeler.StateModel.Sample.Models;
using Modeler.StateModel.Views.AsciiDoc;

namespace Modeler.StateModel.Sample.Views.AsciiDoc;

public class AbsenceStateMachineAsciiDocTableViewDefinition : StateMachineAsciiDocTableViewDefinition
{
    public const string Id = "AbsenceStateMachine";
    
    public static StateMachineAsciiDocTableView Create(HRStateStateMachineModel stateMachineModel)
    {
        var view = new StateMachineAsciiDocTableView(
            Id,
            stateMachineModel.GetStateMachine<StateMachine>());

        return view;
    }
}