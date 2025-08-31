using Modeler.Samples.HR.EventsFlow.Commands;
using Modeler.Samples.HR.EventsFlow.Events;
using Modeler.Samples.HR.Messaging.HRBroker.Events;
using Modeler.Samples.HR.Messaging.HRBroker.Queues;

namespace Modeler.Samples.HR.Messaging;

internal static class MessagingElementsRegistration
{
    internal static void RegisterMessagingElements(this ElementsRegistry elementsRegistry)
    {
        elementsRegistry.AddElement(new SampleQueue());
        elementsRegistry.AddElement(new EmployeeAddedEventMessage());
    }
}