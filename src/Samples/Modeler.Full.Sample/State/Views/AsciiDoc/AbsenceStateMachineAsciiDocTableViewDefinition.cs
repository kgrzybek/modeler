using Modeler.Full.Sample.State.Models;
using Modeler.StateModel;
using Modeler.StateModel.Views.AsciiDoc;

namespace Modeler.Full.Sample.State.Views.AsciiDoc;

public class AbsenceStateMachineAsciiDocTableViewDefinition
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