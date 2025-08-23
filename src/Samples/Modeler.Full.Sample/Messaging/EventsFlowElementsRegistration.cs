using Modeler.Full.Sample.EventsFlow.Commands;
using Modeler.Full.Sample.EventsFlow.Events;

namespace Modeler.Full.Sample.Messaging;

internal static class MessagingElementsRegistration
{
    internal static void RegisterMessagingElements(this ElementsRegistry elementsRegistry)
    {
        elementsRegistry.AddElement(new SampleQueue());
        elementsRegistry.AddElement(new PersonAddedEventMessage());
    }
}