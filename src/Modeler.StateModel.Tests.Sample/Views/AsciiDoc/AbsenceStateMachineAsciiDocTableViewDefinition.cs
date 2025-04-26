using Modeler.StateModel.Views.AsciiDoc;

namespace Modeler.StateModel.Tests.Sample.Views.AsciiDoc;

public class AbsenceStateMachineAsciiDocTableViewDefinition : StateMachineAsciiDocTableViewDefinition
{
    public const string Id = "AbsenceStateMachine";
    
    public static StateMachineAsciiDocTableView Create(OrganizationsStateModel model)
    {
        var view = new StateMachineAsciiDocTableView(
            Id,
            model.GetStateMachine<StateMachine>());

        return view;
    }
}