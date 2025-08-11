using Modeler.Full.Sample.EventsFlow.Commands;
using Modeler.Full.Sample.EventsFlow.Events;

namespace Modeler.Full.Sample.EventsFlow;

internal static class EventsFlowElementsRegistration
{
    internal static void RegisterEventsFlowElements(this ElementsRegistry elementsRegistry)
    {
        elementsRegistry.AddElement(AddEmployeeCommand.Create());
        elementsRegistry.AddElement(RegenerateEmployeesReportCommand.Create());
        elementsRegistry.AddElement(SendNotificationCommand.Create());
        elementsRegistry.AddElement(EmailSentEvent.Create());
        elementsRegistry.AddElement(EmployeeAddedEvent.Create());
        elementsRegistry.AddElement(EmployeeChangedEvent.Create());
        elementsRegistry.AddElement(EmployeesReportRegeneratedEvent.Create());
        elementsRegistry.AddElement(SmsSentEvent.Create());
    }
}