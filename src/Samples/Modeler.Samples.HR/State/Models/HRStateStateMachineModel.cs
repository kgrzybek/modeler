using Modeler.Models.Common;
using Modeler.Models.Common.Elements;
using Modeler.Models.StateMachine;
using Modeler.Samples.HR.State.Models.StateMachines.Absence;

namespace Modeler.Samples.HR.State.Models;

public class HRStateStateMachineModel : StateMachineModel
{
    public HRStateStateMachineModel(ModelElementsRegistry elementsRegistry) : base(elementsRegistry)
    {
        AddStateMachine(AbsenceStateMachine.Create(this));
    }
}