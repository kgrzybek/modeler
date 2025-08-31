using Models.Elements;

namespace Modeler.StateModel;

public abstract class StateMachine : IElement
{
    private readonly List<Transition> _transitions;

    protected StateMachine(string name)
    {
        _transitions = new List<Transition>();
        InitialState = new InitialState();
        EndState = new EndState();
        this.Name = name;
        Id = ElementIdGenerator.GenerateElementId(GetType(), name);
    }
    
    public void AddTransition(State fromState, TransitionEvent @event, State toState)
    {
        _transitions.Add(new Transition(fromState, toState, @event));
    }
    
    public void StartFrom(State fromState, string? description = null)
    {
        _transitions.Add(new Transition(InitialState, fromState, new Description(description)));
    }
    
    public void SetAsEnd(State state, string? description = null)
    {
        _transitions.Add(new Transition(state, EndState, new Description(description)));
    }
    
    public InitialState InitialState { get; }
    
    public EndState EndState { get; }

    public List<State> GetStates()
    {
        var fromStates = _transitions.Select(x => x.FromState).Where(x => x is not StateModel.InitialState).ToList();
        var toStates = _transitions.Select(x => x.ToState).Where(x => x is not StateModel.EndState).ToList();
        
        return fromStates.Concat(toStates).Distinct().ToList();
    }

    public List<Transition> GetTransitions() => _transitions.ToList();

    public List<TransitionEvent> GetTransitionEvents()
    {
        return _transitions.Select(x => x.Event).Where(x => x is not Description).Distinct().ToList();
    }

    public string Name { get; }
    public string Id { get; }
}