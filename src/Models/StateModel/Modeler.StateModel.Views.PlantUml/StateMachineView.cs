using Models.Elements;

namespace Modeler.StateModel.Views.PlantUml;

public class StateMachineView : IView
{
    public StateMachineView(string id, StateMachine stateMachine)
    {
        StateMachine = stateMachine;
        Id = id;
    }

    public StateMachine StateMachine { get; }
    
    public string Id { get; }
}