namespace Modeler.StateModel.Sample;

public class AbsenceStateMachine : StateMachine
{
    public static StateMachine Create(OrganizationsStateModel model)
    {
        var stateMachine = new AbsenceStateMachine();

        var registeredState = new Registered();
        var toDecideState = new ToDecide();
        var needsClarificationState = new NeedsClarificationState();
        var acceptedState = new AcceptedState();
        var rejectedState = new RejectedState();
        
        var sentToDecisionEvent = model.GetEvent<SentToDecisionEvent>();
        var acceptedEvent =  model.GetEvent<AcceptedEvent>();
        var rejectedEvent = model.GetEvent<RejectedEvent>();
        var answeredEvent = model.GetEvent<ClarificationRequestedEvent>();
        
        stateMachine.StartFrom(registeredState);
        stateMachine.AddTransition(registeredState, sentToDecisionEvent, toDecideState);
        stateMachine.AddTransition(toDecideState, answeredEvent, needsClarificationState);
        stateMachine.AddTransition(needsClarificationState, sentToDecisionEvent, toDecideState);
        stateMachine.AddTransition(toDecideState, acceptedEvent, acceptedState);
        stateMachine.AddTransition(toDecideState, rejectedEvent, rejectedState);
        stateMachine.SetAsEnd(acceptedState);
        stateMachine.SetAsEnd(rejectedState);
        
        return stateMachine;
    }
}

public class ToDecide : State
{
    public ToDecide() : base("To Decide")
    {
    }
}

public class Registered : State
{
    public Registered() : base("Registered")
    {
    }
}

public class NeedsClarificationState : State
{
    public NeedsClarificationState() : base("Needs Clarification")
    {
    }
}

public class AcceptedState : State
{
    public AcceptedState() : base("Accepted")
    {
    }
}

public class RejectedState : State
{
    public RejectedState() : base("Rejected")
    {
    }
}