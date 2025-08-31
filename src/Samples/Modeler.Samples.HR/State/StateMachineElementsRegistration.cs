using Modeler.Samples.HR.State.Models.Events;
using Modeler.Samples.HR.State.Models.StateMachines.Absence.States;

namespace Modeler.Samples.HR.State;

internal static class StateMachineElementsRegistration
{
    internal static void RegisterStateMachineElements(this ElementsRegistry elementsRegistry)
    {
        elementsRegistry.AddElement(AcceptedEvent.Create());
        elementsRegistry.AddElement(ClarificationRequestedEvent.Create());
        elementsRegistry.AddElement(RejectedEvent.Create());
        elementsRegistry.AddElement(SentToDecisionEvent.Create());
        
        elementsRegistry.AddElement(new AcceptedState());
        elementsRegistry.AddElement(new NeedsClarificationState());
        elementsRegistry.AddElement(new RegisteredState());
        elementsRegistry.AddElement(new RejectedState());
        elementsRegistry.AddElement(new ToDecideState());
    }
}