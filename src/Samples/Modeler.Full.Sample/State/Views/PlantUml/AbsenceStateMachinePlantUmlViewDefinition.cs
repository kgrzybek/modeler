using Modeler.Full.Sample.State.Models;
using Modeler.StateModel;
using Modeler.StateModel.Views.PlantUml;

namespace Modeler.Full.Sample.State.Views.PlantUml;

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