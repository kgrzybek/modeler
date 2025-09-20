using Modeler.Samples.HR.Components.HRBroker.Events;
using Modeler.Samples.HR.Components.HRBroker.Queues;

namespace Modeler.Samples.HR.Components.HRBroker;

internal static class HRBrokerElementsRegistration
{
    internal static void RegisterHRBrokerElements(this ElementsRegistry elementsRegistry)
    {
        elementsRegistry.AddElement(new SampleQueue());
        elementsRegistry.AddElement(new EmployeeAddedEventMessage());
    }
}