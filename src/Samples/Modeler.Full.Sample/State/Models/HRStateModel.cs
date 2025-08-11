using Modeler.Full.Sample.State.Models.StateMachines.Absence;
using Modeler.StateModel;
using Models.Elements;

namespace Modeler.Full.Sample.State.Models;

public class HRStateModel : Model
{
    public HRStateModel(ModelElementsRegistry elementsRegistry) : base(elementsRegistry)
    {
        AddStateMachine(AbsenceStateMachine.Create(this));
    }
}