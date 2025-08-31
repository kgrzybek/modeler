using Models.Elements;

namespace Modeler.StateModel.Views.PlantUml;

public abstract class PlantUmlStateMachineDiagramView : IView
{
    protected PlantUmlStateMachineDiagramView(StateMachine stateMachine)
    {
        StateMachine = stateMachine;
    }

    public StateMachine StateMachine { get; }
}