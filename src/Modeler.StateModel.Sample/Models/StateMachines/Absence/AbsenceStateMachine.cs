using Modeler.StateModel.Sample.Models.Events;
using Modeler.StateModel.Sample.Models.StateMachines.Absence.States;

namespace Modeler.StateModel.Sample.Models.StateMachines.Absence;

public class AbsenceStateMachine : StateMachine
{
    public static StateMachine Create(HRStateModel model)
    {
        var stateMachine = new AbsenceStateMachine();

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