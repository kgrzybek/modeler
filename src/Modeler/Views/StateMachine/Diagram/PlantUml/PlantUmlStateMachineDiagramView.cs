using Modeler.Models.Common;
using Modeler.Views.Common;

namespace Modeler.Views.StateMachine.Diagram.PlantUml;

public abstract class PlantUmlStateMachineDiagramView : IView
{
    protected PlantUmlStateMachineDiagramView(Models.StateMachine.StateMachine stateMachine)
    {
        StateMachine = stateMachine;
    }

    public Models.StateMachine.StateMachine StateMachine { get; }
}