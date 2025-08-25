using Modeler.Full.Sample.State.Models.StateMachines.Absence;
using Modeler.StateModel;
using Models.Elements;

namespace Modeler.Full.Sample.State.Models;

public class HRStateStateMachineModel : StateMachineModel
{
    public HRStateStateMachineModel(ModelElementsRegistry elementsRegistry) : base(elementsRegistry)
    {
        AddStateMachine(AbsenceStateMachine.Create(this));
    }
}