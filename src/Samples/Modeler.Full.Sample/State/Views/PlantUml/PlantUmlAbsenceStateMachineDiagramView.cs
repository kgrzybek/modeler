using Modeler.Full.Sample.State.Models;
using Modeler.StateModel;
using Modeler.Views.StateMachine.Diagram.PlantUml;

namespace Modeler.Full.Sample.State.Views.PlantUml;

public class PlantUmlAbsenceStateMachineDiagramView : PlantUmlStateMachineDiagramView
{
    public PlantUmlAbsenceStateMachineDiagramView(HRStateStateMachineModel stateMachineModel) : base(stateMachineModel.GetStateMachine<StateMachine>())
    {
    }
}