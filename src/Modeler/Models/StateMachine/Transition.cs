namespace Modeler.Models.StateMachine;

public class Transition
{
    public Transition(State fromState, State toState, TransitionEvent @event)
    {
        FromState = fromState;
        ToState = toState;
        Event = @event;
    }

    public State FromState { get; }
    
    public State ToState { get; }
    
    public TransitionEvent Event { get; }
}