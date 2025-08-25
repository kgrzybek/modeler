using Modeler.StateModel.Sample.Models;
using Modeler.StateModel.Views.PlantUml;

namespace Modeler.StateModel.Sample.Views.PlantUml;

public class AbsenceStateMachinePlantUmlViewDefinition
{
    public const string Id = "AbsenceStateMachine";
    
    public static StateMachineView Create(HRStateStateMachineModel stateMachineModel)
    {
        var view = new StateMachineView(
            Id,
            stateMachineModel.GetStateMachine<StateMachine>());

        return view;
    }
}