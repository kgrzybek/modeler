using Modeler.Samples.HR.Components.HRBroker.Events;
using Modeler.Samples.HR.Components.HRBroker.Queues;

namespace Modeler.Samples.HR.Messaging;

internal static class MessagingElementsRegistration
{
    internal static void RegisterMessagingElements(this ElementsRegistry elementsRegistry)
    {
        elementsRegistry.AddElement(new SampleQueue());
        elementsRegistry.AddElement(new EmployeeAddedEventMessage());
    }
}