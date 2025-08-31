using Modeler.Models.StateMachine;
using Modeler.Samples.HR.State.Models;
using Modeler.Views.StateMachine.Diagram.PlantUml;

namespace Modeler.Samples.HR.State.Views.PlantUml;

public class PlantUmlAbsenceStateMachineDiagramView : PlantUmlStateMachineDiagramView
{
    public PlantUmlAbsenceStateMachineDiagramView(HRStateStateMachineModel stateMachineModel) : base(stateMachineModel.GetStateMachine<StateMachine>())
    {
    }
}