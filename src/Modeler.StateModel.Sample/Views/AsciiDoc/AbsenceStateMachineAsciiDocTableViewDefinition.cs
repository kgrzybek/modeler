using Modeler.StateModel.Sample.Models;
using Modeler.StateModel.Views.AsciiDoc;

namespace Modeler.StateModel.Sample.Views.AsciiDoc;

public class AbsenceStateMachineAsciiDocTableViewDefinition : StateMachineAsciiDocTableViewDefinition
{
    public const string Id = "AbsenceStateMachine";
    
    public static StateMachineAsciiDocTableView Create(HRStateModel model)
    {
        var view = new StateMachineAsciiDocTableView(
            Id,
            model.GetStateMachine<StateMachine>());

        return view;
    }
}