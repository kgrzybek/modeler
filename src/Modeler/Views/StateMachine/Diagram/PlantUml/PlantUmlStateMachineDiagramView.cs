using Models.Elements;

namespace Modeler.Views.StateMachine.Diagram.PlantUml;

public abstract class PlantUmlStateMachineDiagramView : IView
{
    protected PlantUmlStateMachineDiagramView(StateModel.StateMachine stateMachine)
    {
        StateMachine = stateMachine;
    }

    public StateModel.StateMachine StateMachine { get; }
}