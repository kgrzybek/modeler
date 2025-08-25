using Models.Elements;

namespace Modeler.StateModel;

public abstract class StateMachineModel : IModel
{
    private readonly List<TransitionEvent> _events;
    
    private readonly List<StateMachine> _stateMachines;

    protected StateMachineModel(ModelElementsRegistry elementsRegistry)
    {
        _events = elementsRegistry.GetElements<TransitionEvent>();
        _stateMachines = elementsRegistry.GetElements<StateMachine>();
    }
    
    public TransitionEvent GetEvent<T>() where T: TransitionEvent
    {
        var type = _events.OfType<T>().SingleOrDefault();
        
        if (type == null)
        {
            throw new Exception($"Type {typeof(T)} is not defined in the model");
        }

        return type;
    }
    
    public StateMachine GetStateMachine<T>() where T: StateMachine
    {
        var type = _stateMachines.OfType<T>().SingleOrDefault();
        
        if (type == null)
        {
            throw new Exception($"Type {typeof(T)} is not defined in the model");
        }

        return type;
    }

    protected void AddStateMachine(StateMachine stateMachine)
    {
        _stateMachines.Add(stateMachine);
    }
}