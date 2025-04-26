using Modeler.StateModel.Views.PlantUml;

namespace Modeler.StateModel.Tests.Sample;

public class AbsenceStateMachineViewDefinition : StateMachineViewDefinition
{
    public const string Id = "AbsenceStateMachine";
    
    public static StateMachineView Create(OrganizationsStateModel model)
    {
        var view = new StateMachineView(
            Id,
            model.GetStateMachine<StateMachine>());

        return view;
    }
}