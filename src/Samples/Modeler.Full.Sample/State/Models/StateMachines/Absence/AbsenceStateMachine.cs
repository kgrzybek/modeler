using Modeler.Full.Sample.State.Models.Events;
using Modeler.Full.Sample.State.Models.StateMachines.Absence.States;
using Modeler.StateModel;

namespace Modeler.Full.Sample.State.Models.StateMachines.Absence;

public class AbsenceStateMachine : StateMachine
{
    private AbsenceStateMachine(string name) : base(name)
    {
        
    }
    public static StateMachine Create(HRStateModel model)
    {
        var stateMachine = new AbsenceStateMachine("Absence State Machine");

        var registeredState = new RegisteredState();
        var toDecideState = new ToDecideState();
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