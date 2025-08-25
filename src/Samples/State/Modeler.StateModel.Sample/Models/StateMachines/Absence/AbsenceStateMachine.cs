using Modeler.StateModel.Sample.Models.Events;
using Modeler.StateModel.Sample.Models.StateMachines.Absence.States;

namespace Modeler.StateModel.Sample.Models.StateMachines.Absence;

public class AbsenceStateMachine : StateMachine
{
    public AbsenceStateMachine(string name) : base(name)
    {
    }

    public static StateMachine Create(HRStateStateMachineModel stateMachineModel)
    {
        var stateMachine = new AbsenceStateMachine("Absence");

        var registeredState = new RegisteredState();
        var toDecideState = new ToDecideState();
        var needsClarificationState = new NeedsClarificationState();
        var acceptedState = new AcceptedState();
        var rejectedState = new RejectedState();
        
        var sentToDecisionEvent = stateMachineModel.GetEvent<SentToDecisionEvent>();
        var acceptedEvent =  stateMachineModel.GetEvent<AcceptedEvent>();
        var rejectedEvent = stateMachineModel.GetEvent<RejectedEvent>();
        var answeredEvent = stateMachineModel.GetEvent<ClarificationRequestedEvent>();
        
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