using Modeler.Models.Common.Elements;
using Modeler.Models.Messaging;
using Modeler.Samples.HR.Components.ExternalSystems;
using Modeler.Samples.HR.Components.HRBroker.Events;
using Modeler.Samples.HR.Components.HRBroker.Queues;
using Modeler.Samples.HR.Components.System.Backend;
using Modeler.Samples.HR.Components.Types;

namespace Modeler.Samples.HR.Components.HRBroker;

public class HRBrokerComponent : BrokerComponent
{
    public HRBrokerComponent(ModelElementsRegistry elementsRegistry) 
        : base(elementsRegistry, "HR Broker", new MessagesBrokerComponentType())
    {
        var sampleQueue = elementsRegistry.GetElement<SampleQueue>();
        var personAddedEventMessage = elementsRegistry.GetElement<EmployeeAddedEventMessage>();
        var backendApplication = elementsRegistry.GetElement<HRBackendApplication>();
        var crm = elementsRegistry.GetElement<CRM>();
        
        AddQueue(sampleQueue);
        PublishMessage(backendApplication, sampleQueue, personAddedEventMessage);
        SubscribeToMessage(crm, sampleQueue, personAddedEventMessage);
    }
}